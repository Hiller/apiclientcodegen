﻿using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Generators.AutoRest;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Generators.NSwag;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Generators.OpenApi;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Generators.Swagger;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Options;
using System;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Options.General;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Options.NSwag;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Generators
{
    public interface ICodeGeneratorFactory
    {
        ICodeGenerator Create(
            string defaultNamespace,
            string inputFileContents,
            string inputFilePath,
            SupportedLanguage language,
            SupportedCodeGenerator generator);
    }

    public class CodeGeneratorFactory : ICodeGeneratorFactory
    {
        private readonly IOptionsFactory optionsFactory;

        public CodeGeneratorFactory(IOptionsFactory optionsFactory = null)
        {
            this.optionsFactory = optionsFactory ?? new OptionsFactory();
        }

        public ICodeGenerator Create(
            string defaultNamespace,
            string inputFileContents,
            string inputFilePath,
            SupportedLanguage language,
            SupportedCodeGenerator generator)
        {
            switch (generator)
            {
                case SupportedCodeGenerator.AutoRest:
                    return new AutoRestCSharpCodeGenerator(
                        inputFilePath,
                        defaultNamespace);

                case SupportedCodeGenerator.NSwag:
                    var nswagOptions = optionsFactory.Create<INSwagOptions, NSwagOptionsPage>();
                    return new NSwagCSharpCodeGenerator(
                        inputFilePath,
                        defaultNamespace,
                        nswagOptions,
                        new OpenApiDocumentFactory(),
                        new NSwagCodeGeneratorSettingsFactory(defaultNamespace, nswagOptions));

                case SupportedCodeGenerator.Swagger:
                    return new SwaggerCSharpCodeGenerator(
                        inputFilePath,
                        defaultNamespace,
                        optionsFactory.Create<IGeneralOptions, GeneralOptionPage>());

                case SupportedCodeGenerator.OpenApi:
                    return new OpenApiCSharpCodeGenerator(
                        inputFilePath,
                        defaultNamespace,
                        optionsFactory.Create<IGeneralOptions, GeneralOptionPage>());
            }

            throw new NotSupportedException();
        }
    }
}
