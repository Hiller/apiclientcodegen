﻿using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Options.NSwag;
using NJsonSchema.CodeGeneration.CSharp;

namespace ApiClientCodeGen.CLI.Options
{
    public class NSwagOptions : INSwagOptions
    {
        public bool InjectHttpClient { get; } = true;
        public bool GenerateClientInterfaces { get; } = true;
        public bool GenerateDtoTypes { get; } = true;
        public CSharpClassStyle ClassStyle { get; } = CSharpClassStyle.Poco;
        public bool UseDocumentTitle { get; } = true;
        public bool UseBaseUrl { get; }
    }
}