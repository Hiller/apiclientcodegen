﻿using AutoFixture;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Generators;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Generators.Swagger;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Options.General;
using Moq;
using Xunit;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Tests.Generators.Swagger
{
    public class SwaggerCSharpCodeGeneratorYamlTests : TestWithResources
    {
        private readonly Mock<IGeneralOptions> optionsMock = new Mock<IGeneralOptions>();
        private readonly Mock<IProgressReporter> progressMock = new Mock<IProgressReporter>();

        public SwaggerCSharpCodeGeneratorYamlTests()
            => new SwaggerCSharpCodeGenerator(
                    "Swagger.yaml",
                    new Fixture().Create<string>(),
                    optionsMock.Object,
                    new ProcessLauncher())
                .GenerateCode(progressMock.Object);

        [Fact]
        public void Reads_SwaggerCodegenPath()
            => optionsMock.Verify(c => c.SwaggerCodegenPath);

        [Fact]
        public void Updates_Progress()
            => progressMock.Verify(
                c => c.Progress(
                    It.IsAny<uint>(),
                    It.IsAny<uint>()),
                Times.Exactly(5));
    }
}