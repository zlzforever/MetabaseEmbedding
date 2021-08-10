using System;
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
            var token = generator.Create(1, 10);
            
            
        }
    }
}