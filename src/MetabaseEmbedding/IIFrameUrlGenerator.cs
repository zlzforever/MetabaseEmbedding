using System.Collections.Generic;

namespace MetabaseEmbedding
{
    public interface IIFrameUrlGenerator
    {
        /// <summary>
        /// Generate a iframe url
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="exp">Minute</param>
        /// <param name="parameters"></param>
        /// <param name="displayOptions"></param>
        /// <returns>URL</returns>
        string Create(Resource resource, int exp = 10,
            Dictionary<string, object> parameters = null, Dictionary<string, object> displayOptions = null);
    }
}