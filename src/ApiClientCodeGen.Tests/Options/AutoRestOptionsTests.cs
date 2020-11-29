﻿using System;
using ApiClientCodeGen.CLI.Tests.Infrastructure;
using AutoFixture.Xunit2;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Options.AutoRest;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Options.AutoRest;
using FluentAssertions;
using Moq;
using Xunit;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Tests.Options
{
    public class AutoRestOptionsTests
    {
        private readonly IAutoRestOptions options;

        public AutoRestOptionsTests()
            => options = new Mock<IAutoRestOptions>().Object;

        [Xunit.Fact]
        public void Reads_AddCredentials_From_Options()
            => new AutoRestOptions(options)
                .AddCredentials
                .Should()
                .Be(options.AddCredentials);

        [Xunit.Fact]
        public void Reads_ClientSideValidation_From_Options()
            => new AutoRestOptions(options)
                .ClientSideValidation
                .Should()
                .Be(options.ClientSideValidation);

        [Xunit.Fact]
        public void Reads_SyncMethods_From_Options()
            => new AutoRestOptions(options)
                .SyncMethods
                .Should()
                .Be(options.SyncMethods);

        [Xunit.Fact]
        public void Reads_UseDateTimeOffset_From_Options()
            => new AutoRestOptions(options)
                .UseDateTimeOffset
                .Should()
                .Be(options.UseDateTimeOffset);

        [Xunit.Fact]
        public void Reads_UseInternalConstructors_From_Options()
            => new AutoRestOptions(options)
                .UseInternalConstructors
                .Should()
                .Be(options.UseInternalConstructors);

        [Xunit.Fact]
        public void Reads_OverrideClientName_From_Options()
            => new AutoRestOptions(options)
                .OverrideClientName
                .Should()
                .Be(options.OverrideClientName);

        [Theory, AutoMoqData]
        public void Handles_Exception(IAutoRestOptions autoRestOptions)
        {
            Mock.Get(autoRestOptions)
                .Setup(c => c.AddCredentials)
                .Throws<Exception>();
            
            new Action(() => new AutoRestOptions(autoRestOptions))
                .Should()
                .NotThrow();
        }

        [Xunit.Fact]
        public void GetFromDialogPage_If_Options_Null()
            => new Action(() => new AutoRestOptions(null))
                .Should()
                .NotThrow();
    }
}