﻿using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services, DomainOptions options)
    {
        services.AddScoped<ITagCloud, TagCloud>();
        services.AddScoped<IWordExtractor, WordExtractor>();
        services.AddScoped<ITagCloudRenderer, TagCloudRenderer>();
        services.AddScoped<ITagCloudLayouter, TagCloudLayouter>();
        services.AddScoped<IColorProvider, OpacityColorProvider>();
        services.AddScoped<IOptionsValidator, OptionsValidator>();

        switch (options.ServiceOptions.FilterType)
        {
            case FilterType.MorphologicalFilter:
                services.AddScoped<IWordsFilter, MorphologicalFilter>();
                break;
            case FilterType.LengthFilter:
                services.AddScoped<IWordsFilter, LengthFilter>();
                break;
        }

        services.AddSingleton(options.TagCloudOptions);
        services.AddSingleton(options.RenderOptions);
        services.AddSingleton(options.WordExtractionOptions);
        services.AddSingleton(options);

        return services;
    }
}
