# REST API Client Code Generator
A collection of Visual Studio C# custom tool code generators for Swagger / OpenAPI specification files

## Features

- Supports Visual Studio for Mac
- Add New REST API Client to a project from an OpenAPI specification URL (e.g https://petstore.swagger.io/v2/swagger.json) using [AutoRest](https://github.com/Azure/autorest), [NSwag](https://github.com/RicoSuter/NSwag), [Swagger Codegen](https://github.com/swagger-api/swagger-codegen), or [OpenAPI Generator](https://github.com/OpenAPITools/openapi-generator)
- Define custom namespace for the generated file
- Auto-updating of generated code file when changes are made to the OpenAPI specification json file (Swagger.json)
- Generate code using an [NSwagStudio](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio) specification file by including it in the project and using the **Generate with NSwag** context menu


### Custom Tools

- ***AutoRestCodeGenerator*** - Generates a single file C# REST API Client using **AutoRest**. 
The resulting file is the equivalent of using the AutoRest CLI tool with:
` --csharp --input-file=[swaggerFile] --output-file=[outputFile] --namespace=[namespace] --add-credentials`

- ***NSwagCodeGenerator*** - Generates a single file C# REST API Client using the [NSwag.CodeGeneration.CSharp](https://github.com/RSuter/NSwag/wiki/SwaggerToCSharpClientGenerator) [nuget package](https://www.nuget.org/packages/NSwag.CodeGeneration.CSharp/) v13.2.3

- ***SwaggerCodeGenerator*** - Generates a single file C# REST API Client using **Swagger Codegen CLI v3.0.14**.
The output file is the result of merging all the files generated using the Swagger Codegen CLI tool with:
` generate -l csharp --input-spec [swaggerFile] --output [output] -DapiTests=false -DmodelTests=false -DpackageName=[namespace] --skip-overwrite`

- ***OpenApiCodeGenerator*** - Generates a single file C# REST API Client using **OpenAPI Generator v4.2.3**.
The output file is the result of merging all the files generated using the OpenAPI Generator tool with:
` generate -g csharp --input-spec [swaggerFile] --output [output] -DapiTests=false -DmodelTests=false -DpackageName=[namespace] --skip-overwrite`


### Dependencies

The custom tool code generators piggy back on top of well known Open API client code generators like **AutoRest**, **NSwag**, **OpenAPI Generator**, and **Swagger Codegen CLI**. These tools require [NPM](https://www.npmjs.com/get-npm) and the [Java Runtime Environment](https://java.com/en/download/manual.jsp) to be installed on the developers machine. Alternative Java SDK implementations such as the [OpenJDK](https://adoptopenjdk.net) works fine with this extension. By default, the path to **java.exe** is read from the **JAVA_HOME** environment variable, but is also configurable in the Settings screen

The **Swagger Codegen CLI** and **OpenAPI Generator** are distributed as JAR files and are downloaded on demand but requires the Java SDK to be installed on the machine. **AutoRest** is installed on-demand via [NPM](https://www.npmjs.com/get-npm) as a global tool and uses the latest available version. This means that using these custom tools have an initial delay upon first time use. 

**NSwagStudio** is stand alone UI tool for editing a **.nswag** specification file for generating code. This tool is optional to install and official installation instructions are available on the [NSwag Wiki on Github](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio). If **NSwagStudio** is not installed on the machine then the Visual Studio Extension will install the **NSwag CLI** via [NPM](https://www.npmjs.com/get-npm) as a global tool using the latest available version. 

The **OpenAPI Generator** and **Swagger Codegen CLI** code generators produces code that depends on the [RestSharp](https://www.nuget.org/packages/RestSharp/105.1.0) and [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/1.2.0) NuGet packages

The **AutoRest** code generator produces code that depends on the [Microsoft.Rest.ClientRuntime](https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime/2.3.21) and [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/12.0.3) NuGet packages

The **NSwag** code generator produces code that depends on the [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/12.0.3) NuGet package

***NOTE: The brand new Visual Studio for Mac version currently does not have support for automatically adding missing NuGet packages***


## Screenshots

![Add - API Client from OpenAPI Specification](https://github.com/christianhelle/apiclientcodegen/raw/master/images/vsmac-add-new-menu.png)

![Enter URL to OpenAPI Specification](https://github.com/christianhelle/apiclientcodegen/raw/master/images/vsmac-add-new-dialog.png)

![Solution Explorer Context Menus](https://github.com/christianhelle/apiclientcodegen/raw/master/images/vsmac-generate-code.png)

![NSwag Studio Context Menu](https://github.com/christianhelle/apiclientcodegen/raw/master/images/vsmac-nswag-studio.png)

#
For tips and tricks on software development, check out [my blog](https://christian-helle.blogspot.com)

If you find this useful and feel a bit generous then feel free to [buy me a coffee](https://www.buymeacoffee.com/christianhelle) :)
