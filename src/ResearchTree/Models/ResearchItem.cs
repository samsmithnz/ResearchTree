using System;
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
            Width = 162; //Note: Golden Ratio = 1 x 1.618
            Height = 100;
            Edges = new List<Tuple<Vector3, Vector3>>();
        }

        //The name of the research item
        public string Name { get; set; }

        //The amount of work required to complete the research item
        public int CostToComplete { get; set; }

        //The amount of work completed on the research item
        public int WorkCompleted { get; set; }
        public decimal WorkCompletedPercentage
        {
            get
            {
                return (decimal)WorkCompleted / CostToComplete;
            }
        }


        //The number of workers assigned to the research item
        public int WorkersAssigned { get; set; }

        //Whether the research item is complete
        public bool IsComplete
        {
            get
            {
                return WorkCompleted == CostToComplete;
            }
        }

        //The width of the research item
        public int Width { get; set; }

        //The height of the research item
        public int Height { get; set; }


        //The items that are required to be finished before this item can start
        public List<string> PreReqs { get; set; }

        //The Level describes the order in which the research item appears on the graph - based on the prereqs
        public int Level { get; set; }


        //Top left position
        public Vector3 Location { get; set; }

        //List of edges from the item and it's prereqs 
        public List<Tuple<Vector3, Vector3>> Edges { get; set; }
        //TODO: Consider a readonly list of starting Vector3 and line length
        //public List<(Vector3, int)> EdgeLengths { get; set; }
    }
}
