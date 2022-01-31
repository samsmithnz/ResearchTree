using System.Collections.Generic;

namespace ResearchTree.Models
{
    public class ResearchItem
    {
        public ResearchItem()
        {
            PreReqs = new List<string>();
        }

        public string Name { get; set; }
        public List<string> PreReqs { get; set; }
        public int WorkToComplete { get; set; }
        public int WorkCompleted { get; set; }
        public bool IsComplete { get; set; }

    }
}
