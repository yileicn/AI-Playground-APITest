namespace APITestTool
{
    /// <summary>
    /// API测试结果
    /// </summary>
    public class ApiTestResult
    {
        public int Index { get; set; }
        public int StatusCode { get; set; }
        public long Duration { get; set; }
        public string? ResponseBody { get; set; }
        public string? FormattedResponse { get; set; }
        public int ResponseSize { get; set; }
        public string? ResponseHash { get; set; }
        public string? CompareHash { get; set; } // 用于字段对比的Hash
        public bool IsSuccess { get; set; }
        public bool IsDifferent { get; set; }
    }

    /// <summary>
    /// 保存的请求配置
    /// </summary>
    public class SavedRequest
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";
        public string Method { get; set; } = "GET";
        public string Headers { get; set; } = "";
        public string Body { get; set; } = "";
        public string? CompareFields { get; set; } = "";
        public bool CompareFieldsOnly { get; set; }
        public int CallCount { get; set; } = 10;
        public int Timeout { get; set; } = 30;
        public int Delay { get; set; } = 100;
        public bool IsParallel { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    #region AI Playground 相关模型

    /// <summary>
    /// Prompt 配置
    /// </summary>
    public class PromptConfig
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Model { get; set; } = "gpt-4o";
        public string SystemPrompt { get; set; } = ""; // 支持 {{变量名}} 模板
        public double Temperature { get; set; } = 0.7;
        public int MaxTokens { get; set; } = 2048;
        public double TopP { get; set; } = 1.0;
        public double FrequencyPenalty { get; set; } = 0;
        public double PresencePenalty { get; set; } = 0;
        public List<PromptVariable> Variables { get; set; } = new();
        public List<FunctionDefinition> Functions { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Prompt 变量
    /// </summary>
    public class PromptVariable
    {
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
        public string Description { get; set; } = "";
    }

    /// <summary>
    /// 聊天消息（内部使用，避免与 OpenAI.Chat.ChatMessage 冲突）
    /// </summary>
    public class ConversationMessage
    {
        public string Role { get; set; } = "user"; // system, user, assistant, tool
        public string Content { get; set; } = "";
        public string ToolCallId { get; set; } = ""; // 用于 tool role
        public List<ToolCallInfo>? ToolCalls { get; set; } = null; // 用于 assistant role，当包含 tool_calls 时
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// AI Playground 测试结果
    /// </summary>
    public class PromptTestResult
    {
        public int Index { get; set; }
        public string Model { get; set; } = "";
        public string Input { get; set; } = "";
        public string Output { get; set; } = "";
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
        public long Duration { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// OpenAI API 设置
    /// </summary>
    public class OpenAISettings
    {
        public string ApiKey { get; set; } = "";
        public string BaseUrl { get; set; } = "https://api.openai.com/v1";
        public string Organization { get; set; } = "";
        public bool UseEnvironmentVariable { get; set; } = false;
        public string EnvironmentVariableName { get; set; } = "OPENAI_API_KEY";
    }

    /// <summary>
    /// Function 定义（用于 Function Calling）
    /// </summary>
    public class FunctionDefinition
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Parameters { get; set; } = ""; // JSON Schema 字符串
    }

    /// <summary>
    /// ChatCompletion 响应（用于序列化）
    /// </summary>
    public class ChatCompletionResponse
    {
        public string? Content { get; set; }
        public List<ToolCallInfo>? ToolCalls { get; set; }
        public TokenUsage? Usage { get; set; }
    }

    /// <summary>
    /// 工具调用信息（用于序列化）
    /// </summary>
    public class ToolCallInfo
    {
        public string Id { get; set; } = "";
        public string Type { get; set; } = "";
        public FunctionCallInfo Function { get; set; } = new();
    }

    /// <summary>
    /// 函数调用信息（用于序列化）
    /// </summary>
    public class FunctionCallInfo
    {
        public string Name { get; set; } = "";
        public object? Arguments { get; set; }
    }

    /// <summary>
    /// Token 使用情况（用于序列化）
    /// </summary>
    public class TokenUsage
    {
        public int? PromptTokens { get; set; }
        public int? CompletionTokens { get; set; }
        public int? TotalTokens { get; set; }
    }

    #endregion
}

