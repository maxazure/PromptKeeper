# PromptKeeper Desktop Application

PromptKeeper is a desktop application designed to manage and generate prompts efficiently, enhancing the usage of chatbots and other interactive systems that rely on prompt-driven interaction.

## Features

- **Template Management**: Allows users to save, edit, and manage templates for generating prompts.
- **Contextual Prompt Generation**: Enhances prompt generation by adding contextual information based on user selections.
- **SQL Query Support**: Automatically adds environment context to SQL queries.
- **Translation Support**: Adds information to translate statements from Chinese to English focusing on native speaker nuances.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them:

- .NET 8
- Any compatible IDE like Visual Studio

### Installing

使用前请先设置环境变量
`PROMPT_KEEPER_API_BASE_URI`，指向你的`API`服务器的URL。

A step-by-step series of examples that tell you how to get a development environment running:


1. **Clone the repository:**

2. Navigate to the project directory:
   cd PromptKeeper

3. Restore dependencies:

In Visual Studio, you can restore dependencies by right-clicking on the solution and selecting "Restore NuGet Packages."

4. Build the project:
	dotnet build

Usage
How to use the application:

Adding a Template: Go to the Template Management section, click "Add", and fill in the details.
Generating Prompts: Select a template from the list and input any required information to generate a prompt based on the selected template.
Contributing
We welcome contributions. Please read CONTRIBUTING.md for details on our code of conduct, and the process for submitting pull requests to us.

Versioning
We use SemVer for versioning. For the versions available, see the tags on this repository.