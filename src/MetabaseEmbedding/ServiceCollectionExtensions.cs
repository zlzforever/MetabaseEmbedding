using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MetabaseEmbedding
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMetabaseEmbedding(this IServiceCollection serviceCollection,
            IConfiguration configuration, string section = "Metabase")
        {
            serviceCollection.TryAddScoped<IIFrameUrlGenerator, IFrameUrlGenerator>();
            serviceCollection.Configure<MetabaseOptions>(configuration.GetSection(section));
            return serviceCollection;
        }
    }
}