# AI API Test Tool

一个功能强大的 Windows API 测试工具，专为测试 API 接口的稳定性和一致性而设计。支持批量请求、响应对比、差异分析等功能。

<img width="1842" height="1007" alt="" src="https://github.com/user-attachments/assets/7170a4ff-e081-4b07-b167-2f025871f620" />


![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-0078D6?style=flat-square&logo=windows)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

## ✨ 功能特性

### 🚀 批量请求测试
- 支持 **GET、POST、PUT、PATCH、DELETE** 等 HTTP 方法
- 可配置请求次数（1-10000次）
- 支持**顺序执行**和**并行执行**两种模式
- 可设置请求间隔延迟和超时时间

### 🔍 响应差异分析
- 自动检测多次请求响应的差异
- 支持**完整响应对比**和**指定字段对比**两种模式
- 使用 MD5 Hash 快速识别不同响应
- 详细的 JSON 差异对比报告

### 📊 统计报告
- 请求成功/失败统计
- 响应时间分析（平均、最小、最大、P50/P90/P95/P99）
- 状态码分布统计
- 响应一致性分析

### 💾 请求管理
- 保存常用请求配置
- 支持导入/导出请求配置（JSON格式）
- 双击快速加载已保存的请求

### 🛠️ 实用工具
- 文本转 JSON 字符串工具（自动转义特殊字符）
- 响应内容格式化显示
- 双击查看完整响应详情

## 📦 安装要求

- Windows 10/11
- .NET 8.0 Runtime

## 🚀 快速开始

### 从源码构建

```bash
# 克隆仓库
git clone https://github.com/your-username/AI-API-Test-Tool.git
cd AI-API-Test-Tool

# 构建项目
dotnet build

# 运行
dotnet run
```

### 直接运行

下载 Release 中的可执行文件，双击运行 `AIAPITestTool.exe`。

## 📖 使用说明

### 基本使用

1. **输入 API URL** - 在 URL 输入框中填写要测试的 API 地址
2. **选择请求方法** - 从下拉框选择 GET、POST 等方法
3. **配置 Headers**（可选）- 以 JSON 格式输入请求头
   ```json
   {
     "Authorization": "Bearer your-token",
     "Content-Type": "application/json"
   }
   ```
4. **配置 Body**（可选）- 对于 POST/PUT/PATCH 请求，输入请求体
5. **设置测试参数**
   - 调用次数：执行请求的次数
   - 超时时间：单次请求的超时秒数
   - 请求间隔：顺序执行时每次请求的间隔毫秒数
   - 并行执行：是否同时发送多个请求
6. **点击执行** - 开始测试

### 字段对比功能

当 API 响应中包含动态字段（如时间戳、随机ID）时，可以使用字段对比功能只对比关心的字段：

1. 在"对比字段"文本框中输入要对比的字段路径，每行一个
2. 勾选"仅对比指定字段"
3. 执行测试

**字段路径格式示例：**
```
data.user.id
data.items[0].name
result.list[2].value
response.nested.deep.field
```

### 保存和管理请求

- **保存请求** - 点击"保存"按钮，输入名称保存当前配置
- **加载请求** - 双击左侧列表中的已保存请求
- **删除请求** - 选中请求后点击"删除"按钮
- **导出/导入** - 使用导出/导入按钮备份或分享请求配置

## 🎨 界面预览

工具采用现代深色主题设计，界面清晰直观：

- **左侧面板** - 请求配置和已保存请求列表
- **右侧上方** - 测试结果表格，显示每次请求的状态码、耗时、响应大小等
- **右侧下方** - 差异分析和统计报告标签页

## 🔧 技术栈

- **框架**: .NET 8.0 Windows Forms
- **JSON处理**: Newtonsoft.Json
- **UI主题**: Catppuccin Mocha 配色方案

## 📁 项目结构

```
AI-API-Test-Tool/
├── MainForm.cs              # 主窗体逻辑
├── MainForm.Designer.cs     # 主窗体设计器代码
├── MainForm.resx            # 主窗体资源文件
├── Models.cs                # 数据模型定义
├── Program.cs               # 程序入口
├── SaveRequestDialog.cs     # 保存请求对话框
├── TextToJsonDialog.cs      # 文本转JSON对话框
├── AIAPITestTool.csproj     # 项目文件
└── AIAPITestTool.sln        # 解决方案文件
```

## 📝 数据存储

已保存的请求配置存储在：
```
%APPDATA%\APITestTool\saved_requests.json
```

## 🤝 贡献

欢迎提交 Issue 和 Pull Request！

## 📄 许可证

本项目采用 MIT 许可证 - 详见 [LICENSE](LICENSE) 文件。
