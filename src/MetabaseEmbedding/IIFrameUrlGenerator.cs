using System.Collections.Generic;

namespace MetabaseEmbedding
{
    public interface IIFrameUrlGenerator
    {
        /// <summary>
        /// Generate a iframe url
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <param name="exp">Minute</param>
        /// <param name="displayOptions"></param>
        /// <returns>URL</returns>
        string Create(ResourceType type, int id, Dictionary<string, object> parameters = null, int exp = 10,
            Dictionary<string, string> displayOptions = null);
    }
}