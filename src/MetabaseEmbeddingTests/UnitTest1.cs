using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using MetabaseEmbedding;
using Microsoft.Extensions.Configuration;

namespace MetabaseEmbeddingTests
{
    public class UnitTest1
    {
        [Fact]
        public void Create()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            serviceCollection.AddMetabaseEmbedding(configuration);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var generator = serviceProvider.GetRequiredService<IIFrameUrlGenerator>();
            var url = generator.Create(ResourceType.Dashboard, 9, new Dictionary<string, object>
            {
                { "type", "ZXXD" }
            }, 10, new Dictionary<string, string>
            {
                { "bordered", "false" },
                { "titled", "false" },
            });
        }
    }
}