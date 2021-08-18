namespace MetabaseEmbedding
{
    public class Resource
    {
        public ResourceType Type { get; }
        public int Id { get; }

        public Resource(ResourceType type, int id)
        {
            Type = type;
            Id = id;
        }

        public static Resource CreateQuestion(int id)
        {
            return new Resource(ResourceType.Question, id);
        }

        public static Resource CreateDashboard(int id)
        {
            return new Resource(ResourceType.Dashboard, id);
        }
    }
}