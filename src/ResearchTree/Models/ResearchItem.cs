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
            Width = 100; //Golden Ratio = 1 x 1.618
            Height = 100;
            Edges = new List<Tuple<Vector3, Vector3>>();
        }

        public string Name { get; set; }
        public List<string> PreReqs { get; set; }
        public int WorkToComplete { get; set; }
        private int _workCompleted;
        public int WorkCompleted
        {
            get
            {
                return _workCompleted;
            }
            set
            {
                _workCompleted = value;
                if (_workCompleted >= WorkToComplete)
                {
                    IsComplete = true;
                    WorkersAssigned = 0;
                }
            }
        }
        public int WorkersAssigned { get; set; }
        public bool IsComplete { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Level { get; set; }

        //Top left position
        public Vector3 Location { get; set; }
        //List of edges from the item and it's prereqs 
        public List<Tuple<Vector3, Vector3>> Edges { get; set; }
        //TODO: Consider a readonly list of starting Vector3 and line length
        //public List<(Vector3, int)> EdgeLengths { get; set; }
    }
}
