using System.Text.Json;
using JWT;

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