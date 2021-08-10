namespace MetabaseEmbedding
{
    public interface IIFrameUrlGenerator
    {
        /// <summary>
        /// Generate a iframe url
        /// </summary>
        /// <param name="question"></param>
        /// <param name="exp">Minute</param>
        /// <returns>URL</returns>
        string Create(int question, int exp);
    }
}