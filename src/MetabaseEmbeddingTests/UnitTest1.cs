using System;
using System.Collections.Generic;
using System.Linq;
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
            var url = generator.Create(ResourceType.Dashboard, 9, new Dictionary<string, string>
            {
                { "type", "SLDC" }
            }, 10, new Dictionary<string, string>
            {
                { "bordered", "false" },
                { "titled", "false" },
            });
        }

        [Fact]
        public void JsonSerializerTest()
        {
            var payload = Payload.Create(ResourceType.Question, 10, new Dictionary<string, string>
            {
                { "type", "ZXXD" }
            }, 10);
            var json = JsonSerializer.Instance.Serialize(payload);
            var obj = JsonSerializer.Instance.Deserialize<Payload>(json);
            Assert.Equal("question", payload.Resource.Keys.First());
            Assert.Equal(10, payload.Resource.Values.First());
            Assert.Equal("type", payload.Params.Keys.First());
            Assert.Equal("ZXXD", payload.Params.Values.First());
        }
    }
}