
namespace ResearchTree.Models
{
    public class ResearchItem
    {
        public string Name { get; set; }
        public ResearchItem ResearchPrereq { get; set; }
        public int WorkToComplete { get; set; }
        public int WorkCompleted { get; set; }
        public bool IsComplete { get; set; }

    }
}
