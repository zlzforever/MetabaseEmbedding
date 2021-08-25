using System.Collections.Generic;
using System.Text.Json;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace MetabaseEmbedding
{
    internal class Payload
    {
        private static readonly Dictionary<string, object> EmptyObject = new();

        public IReadOnlyDictionary<string, int> Resource { get; }
        public IReadOnlyDictionary<string, object> Params { get; }

        /// <summary>
        /// Exp minute
        /// </summary>
        public long Exp { get; }

        private Payload(Dictionary<string, int> resource,
            Dictionary<string, object> parameters, long exp = 10)
        {
            Resource = resource;
            Params = parameters;
            Exp = exp;
        }

        public static Payload Create(ResourceType type, int id, Dictionary<string, object> parameters, long exp = 10)
        {
            return new Payload(new Dictionary<string, int>
            {
                { type.Name, id }
            }, parameters ?? EmptyObject, exp);
        }

        public override string ToString()
        {
            return JsonSerializer.Instance.Serialize(this);
        }
    }
}