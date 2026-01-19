using System.ClientModel;
using Newtonsoft.Json;
using OpenAI.Chat;

namespace APITestTool
{
    /// <summary>
    /// OpenAI 聊天服务，封装聊天相关的业务逻辑
    /// </summary>
    public class OpenAIChatService
    {
        /// <summary>
        /// 构建消息列表
        /// </summary>
        public static List<ChatMessage> BuildMessages(string systemPrompt, List<ConversationMessage> conversationHistory, List<ChatMessage>? assistantMessagesWithToolCalls = null)
        {
            var messages = new List<ChatMessage>();
            int assistantMessageIndex = 0; // 用于跟踪 assistant 消息的索引

            // 添加 System Prompt
            if (!string.IsNullOrEmpty(systemPrompt))
            {
                messages.Add(ChatMessage.CreateSystemMessage(systemPrompt));
            }

            // 添加对话历史
            foreach (var msg in conversationHistory)
            {
                switch (msg.Role.ToLower())
                {
                    case "user":
                        messages.Add(ChatMessage.CreateUserMessage(msg.Content));
                        break;
                    case "assistant":
                        // 如果这是包含 tool_calls 的 assistant 消息，直接使用保存的原始消息
                        if (msg.ToolCalls != null && msg.ToolCalls.Count > 0 && assistantMessagesWithToolCalls != null && assistantMessageIndex < assistantMessagesWithToolCalls.Count)
                        {
                            // 按顺序使用保存的 assistant 消息
                            messages.Add(assistantMessagesWithToolCalls[assistantMessageIndex]);
                            assistantMessageIndex++;
                        }
                        else
                        {
                            messages.Add(ChatMessage.CreateAssistantMessage(msg.Content ?? ""));
                        }
                        break;
                    case "system":
                        messages.Add(ChatMessage.CreateSystemMessage(msg.Content));
                        break;
                    case "tool":
                        // Tool message 必须紧跟在包含 tool_calls 的 assistant 消息之后
                        // 格式: ChatMessage.CreateToolMessage(toolCallId, content)
                        if (!string.IsNullOrEmpty(msg.ToolCallId) && !string.IsNullOrEmpty(msg.Content))
                        {
                            messages.Add(ChatMessage.CreateToolMessage(msg.ToolCallId, msg.Content));
                        }
                        break;
                    default:
                        messages.Add(ChatMessage.CreateUserMessage(msg.Content));
                        break;
                }
            }

            return messages;
        }

        /// <summary>
        /// 从 FunctionDefinition 列表创建 ChatTool 列表
        /// </summary>
        public static List<ChatTool> CreateTools(List<FunctionDefinition> functions)
        {
            var toolsList = new List<ChatTool>();

            foreach (var func in functions)
            {
                try
                {
                    // 确保 Parameters JSON Schema 格式正确
                    string parametersJson = func.Parameters;

                    // 如果 Parameters 为空，创建一个基本的 JSON Schema
                    if (string.IsNullOrWhiteSpace(parametersJson))
                    {
                        parametersJson = """{"type":"object","properties":{},"required":[]}""";
                    }

                    // 验证 JSON 格式
                    try
                    {
                        JsonConvert.DeserializeObject(parametersJson);
                    }
                    catch
                    {
                        // 如果 JSON 格式不正确，使用基本格式
                        parametersJson = """{"type":"object","properties":{},"required":[]}""";
                    }

                    // 使用 ChatTool.CreateFunctionTool 创建工具
                    var tool = ChatTool.CreateFunctionTool(
                        functionName: func.Name,
                        functionDescription: func.Description ?? "",
                        functionParameters: BinaryData.FromString(parametersJson)
                    );

                    toolsList.Add(tool);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"创建 Function Tool {func.Name} 失败: {ex.Message}");
                    throw;
                }
            }

            return toolsList;
        }

        /// <summary>
        /// 创建聊天完成选项
        /// </summary>
        public static ChatCompletionOptions CreateOptions(double temperature, double topP, int maxTokens, List<ChatTool>? tools = null)
        {
            var options = new ChatCompletionOptions
            {
                Temperature = (float)temperature,
                TopP = (float)topP
            };

            // 添加 Tools
            if (tools != null && tools.Count > 0)
            {
                foreach (var tool in tools)
                {
                    options.Tools.Add(tool);
                }
            }

            // MaxTokens 通过反射设置（如果属性存在）
            try
            {
                var maxTokensProp = typeof(ChatCompletionOptions).GetProperty("MaxTokens");
                if (maxTokensProp != null)
                {
                    maxTokensProp.SetValue(options, maxTokens);
                }
            }
            catch
            {
                // MaxTokens 设置失败不影响主要功能
            }

            return options;
        }

        /// <summary>
        /// 将 ChatCompletion 转换为 ChatCompletionResponse
        /// </summary>
        public static ChatCompletionResponse MapToResponse(ChatCompletion completion)
        {
            var response = new ChatCompletionResponse();

            // 提取文本内容
            try
            {
                if (completion.Content != null && completion.Content.Count > 0)
                {
                    var firstContent = completion.Content[0];
                    var textProp = firstContent.GetType().GetProperty("Text");
                    if (textProp != null)
                    {
                        response.Content = textProp.GetValue(firstContent)?.ToString();
                    }
                    else
                    {
                        response.Content = firstContent.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"提取文本内容失败: {ex.Message}");
            }

            // 提取工具调用
            if (completion.ToolCalls != null && completion.ToolCalls.Count > 0)
            {
                response.ToolCalls = new List<ToolCallInfo>();

                foreach (var toolCall in completion.ToolCalls)
                {
                    var toolCallInfo = new ToolCallInfo
                    {
                        Id = toolCall.Id ?? "",
                        Type = toolCall.Kind.ToString() ?? ""
                    };

                    // 直接访问 FunctionName 和 FunctionArguments 属性
                    toolCallInfo.Function = new FunctionCallInfo
                    {
                        Name = toolCall.FunctionName ?? ""
                    };

                    // 处理 FunctionArguments (BinaryData)
                    if (toolCall.FunctionArguments != null)
                    {
                        string argumentsJson = toolCall.FunctionArguments.ToString();
                        try
                        {
                            // 尝试解析为 JSON 对象
                            toolCallInfo.Function.Arguments = JsonConvert.DeserializeObject(argumentsJson);
                        }
                        catch
                        {
                            // 如果解析失败，保持为字符串
                            toolCallInfo.Function.Arguments = argumentsJson;
                        }
                    }

                    response.ToolCalls.Add(toolCallInfo);
                }
            }

            // 提取 Token 使用情况
            if (completion.Usage != null)
            {
                response.Usage = ExtractTokenUsage(completion.Usage);
            }

            return response;
        }

        /// <summary>
        /// 提取 Token 使用情况
        /// </summary>
        private static TokenUsage ExtractTokenUsage(object usage)
        {
            var tokenUsage = new TokenUsage();
            var usageType = usage.GetType();

            var promptTokensProp = usageType.GetProperty("PromptTokens")
                ?? usageType.GetProperty("InputTokens")
                ?? usageType.GetProperty("InputTokenCount");

            var completionTokensProp = usageType.GetProperty("CompletionTokens")
                ?? usageType.GetProperty("OutputTokens")
                ?? usageType.GetProperty("OutputTokenCount");

            var totalTokensProp = usageType.GetProperty("TotalTokens");

            if (promptTokensProp != null)
            {
                var value = promptTokensProp.GetValue(usage);
                if (value != null)
                {
                    tokenUsage.PromptTokens = Convert.ToInt32(value);
                }
            }

            if (completionTokensProp != null)
            {
                var value = completionTokensProp.GetValue(usage);
                if (value != null)
                {
                    tokenUsage.CompletionTokens = Convert.ToInt32(value);
                }
            }

            if (totalTokensProp != null)
            {
                var value = totalTokensProp.GetValue(usage);
                if (value != null)
                {
                    tokenUsage.TotalTokens = Convert.ToInt32(value);
                }
            }

            return tokenUsage;
        }

        /// <summary>
        /// 格式化响应内容（如果有工具调用，返回 JSON；否则返回文本）
        /// </summary>
        public static string FormatResponse(ChatCompletionResponse response)
        {
            if (response.ToolCalls != null && response.ToolCalls.Count > 0)
            {
                // 如果有工具调用，序列化工具调用列表
                return JsonConvert.SerializeObject(response.ToolCalls, Formatting.Indented);
            }
            else
            {
                // 否则显示文本内容
                return response.Content ?? "[空响应]";
            }
        }
    }
}
