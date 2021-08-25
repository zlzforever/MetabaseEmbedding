using System.Collections.Generic;

namespace MetabaseEmbedding
{
    public interface IIFrameUrlGenerator
    {
        string Create(Payload payload, Dictionary<string, string> displayOptions = null);

        /// <summary>
        /// Generate a iframe url
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <param name="exp">Minute</param>
        /// <param name="displayOptions"></param>
        /// <returns>URL</returns>
        string Create(ResourceType type, int id, Dictionary<string, string> parameters = null, int exp = 10,
            Dictionary<string, string> displayOptions = null);
    }
}