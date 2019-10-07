﻿namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Options.NSwag
{
    public interface INSwagStudioOptions : INSwagOptions
    {
        bool GenerateResponseClasses { get; }
        bool GenerateJsonMethods { get; }
        bool RequiredPropertiesMustBeDefined { get; }
        bool GenerateDefaultValues { get; }
        bool GenerateDataAnnotations { get; }
    }
}