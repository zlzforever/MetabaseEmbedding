namespace MetabaseEmbedding
{
    public class ResourceType
    {
        public static readonly ResourceType Question = new("question");
        public static readonly ResourceType Dashboard = new("dashboard");

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        private ResourceType(string name)
        {
            Name = name;
        }
    }
}