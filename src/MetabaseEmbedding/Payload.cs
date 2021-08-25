using System.Collections.Generic;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace MetabaseEmbedding
{
    public class Payload
    {
        private static readonly Dictionary<string, string> EmptyObject = new();

        public Dictionary<string, int> Resource { get; set; }
        public Dictionary<string, string> Params { get; set; }

        /// <summary>
        /// Exp minute
        /// </summary>
        public long Exp { get; set; }

        public static Payload Create(ResourceType type, int id, Dictionary<string, string> parameters, long exp = 10)
        {
            return new Payload
            {
                Resource = new Dictionary<string, int>
                {
                    { type.Name, id }
                },
                Params = parameters ?? EmptyObject,
                Exp = exp
            };
        }

        public override string ToString()
        {
            return JsonSerializer.Instance.Serialize(this);
        }
    }
}