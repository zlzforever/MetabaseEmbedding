using System;

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

        public static ResourceType Get(string name)
        {
            switch (name)
            {
                case "question":
                {
                    return Question;
                }
                case "dashboard":
                {
                    return Dashboard;
                }
                default:
                {
                    throw new NotSupportedException($"Not supported type {name}");
                }
            }
        }

        private ResourceType(string name)
        {
            Name = name;
        }
    }
}