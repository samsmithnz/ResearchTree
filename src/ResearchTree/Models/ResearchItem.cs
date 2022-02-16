using System.Collections.Generic;
using System.Numerics;

namespace ResearchTree.Models
{
    public class ResearchItem
    {
        public ResearchItem()
        {
            PreReqs = new List<string>();
            Location = Vector3.Zero;
            Width = 100;
            Height = 100;
        }

        public string Name { get; set; }
        public List<string> PreReqs { get; set; }
        public int WorkToComplete { get; set; }
        public int WorkCompleted { get; set; }
        public bool IsComplete { get; set; }
        //Top left position
        public Vector3 Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Level { get; set; }
    }
}
