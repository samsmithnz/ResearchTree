using System.Collections.Generic;
using System.Numerics;

namespace ResearchTree.Models
{
    public class ResearchItem
    {
        public ResearchItem()
        {
            PreReqs = new List<string>();
            Position = Vector3.Zero;
        }

        public string Name { get; set; }
        public List<string> PreReqs { get; set; }
        public int WorkToComplete { get; set; }
        public int WorkCompleted { get; set; }
        public bool IsComplete { get; set; }
        public Vector3 Position { get; set; }
    }
}
