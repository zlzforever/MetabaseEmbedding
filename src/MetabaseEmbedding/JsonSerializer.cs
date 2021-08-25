using System.Runtime.CompilerServices;
using System.Text.Json;
using JWT;

[assembly: InternalsVisibleTo("MetabaseEmbeddingTests")]

namespace MetabaseEmbedding
{
    internal class JsonSerializer : IJsonSerializer
    {
        public static readonly IJsonSerializer Instance = new JsonSerializer();

        public string Serialize(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public T Deserialize<T>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}