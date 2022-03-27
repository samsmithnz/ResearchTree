using ResearchTree.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ResearchTree
{
    public class ResearchController
    {
        public List<ResearchItem> ResearchItems { get; set; }
        public int ItemWidth { get; set; }
        public int ItemHeight { get; set; }
        public int ItemWidthBuffer { get; set; }
        public int ItemHeightBuffer { get; set; }
        public int WorkersAvailable { get; set; }

        public ResearchController(List<ResearchItem> items,
            int itemWidth = 100, int itemHeight = 100,
            int itemWidthBuffer = 50, int itemHeightBuffer = 50)
        {
            ItemWidth = itemWidth;
            ItemHeight = itemHeight;
            ItemWidthBuffer = itemWidthBuffer;
            ItemHeightBuffer = itemHeightBuffer;


            //Verify that all of the children exist
            ValidateItems(items);

            //Assign levels to each research item.
            AssignLevels(items, itemWidth, itemHeight);

            //Now assign positions, based on the level and parent.
            //First look at a level - how many items do we have? Center these vertically as appropriate
            Dictionary<int, int> levelCounts = new Dictionary<int, int>();
            foreach (ResearchItem item in items)
            {
                if (levelCounts.ContainsKey(item.Level))
                {
                    levelCounts[item.Level]++;
                }
                else
                {
                    levelCounts.Add(item.Level, 1);
                }
            }

            //TODO: Now look at pre-reqs. How many parents does each item have. Center these vertically as appropriate

            //Now place the squares. If we go backwards here, we build the list in the order that it's created
            for (int i = items.Count - 1; i >= 0; i--)
            {
                ResearchItem item = items[i];
                //Horizontal location is the center of the square, calculated with width buffer + the width of the item, based on the level
                float x = (itemWidthBuffer * item.Level) + (item.Width * (item.Level - 1)) + item.Width / 2;
                float y = (itemHeightBuffer * levelCounts[item.Level]) + (item.Height * (levelCounts[item.Level] - 1)) + item.Height / 2;
                levelCounts[item.Level]--;
                item.Location = new Vector3(x, y, 0f);
            }

            //Finally draw lines between each node
            foreach (ResearchItem item in items)
            {
                if (item.PreReqs.Count > 0) //item.Name == "H" &&
                {
                    foreach (string prereq in item.PreReqs)
                    {
                        ResearchItem prereqItem = FindItem(items, prereq);
                        //If the item is at the same Y position, draw a single straight line
                        if (prereqItem.Location.Y == item.Location.Y)
                        {
                            Tuple<Vector3, Vector3> tuple1 = CreateTuple(
                                new Vector3(prereqItem.Location.X, prereqItem.Location.Y, 0f),
                                new Vector3(item.Location.X, item.Location.Y, 0f));
                            if (item.Edges.Contains(tuple1) == false)
                            {
                                item.Edges.Add(tuple1);
                            }
                        }
                        else
                        {
                            int xMidpoint = (int)(item.Location.X - (prereqItem.Width / 2) - (ItemWidthBuffer / 2));

                            //We need to add two half horizontal lines, and a vertical line
                            Tuple<Vector3, Vector3> tuple1 = CreateTuple(
                                new Vector3(prereqItem.Location.X, prereqItem.Location.Y, 0f),
                                new Vector3(xMidpoint, prereqItem.Location.Y, 0f));
                            if (item.Edges.Contains(tuple1) == false)
                            {
                                item.Edges.Add(tuple1);
                            }

                            Tuple<Vector3, Vector3> tuple2 = CreateTuple(
                                new Vector3(xMidpoint, item.Location.Y, 0f),
                                new Vector3(item.Location.X, item.Location.Y, 0f));
                            if (item.Edges.Contains(tuple2) == false)
                            {
                                item.Edges.Add(tuple2);
                            }

                            Tuple<Vector3, Vector3> tuple3 = CreateTuple(
                                new Vector3(xMidpoint, prereqItem.Location.Y, 0f),
                                new Vector3(xMidpoint, item.Location.Y, 0f));
                            if (item.Edges.Contains(tuple3) == false)
                            {
                                item.Edges.Add(tuple3);
                            }
                        }
                    }
                }
            }

            ResearchItems = items;
        }

        public bool AddTick()
        {
            foreach (ResearchItem item in ResearchItems)
            {
                //If the item is active with workers assigned
                if (item.IsComplete == false && item.WorkersAssigned > 0)
                {
                    //Increment the work done
                    item.WorkCompleted += item.WorkersAssigned;
                    //If the work is completed, mark the research as done!
                    if (item.WorkCompleted == item.WorkToComplete && item.IsComplete == false)
                    {
                        item.IsComplete = true;
                    }
                }
            }
            return true;
        }

        //Attempt to order the vectors, so that the top left one is first.
        private Tuple<Vector3, Vector3> CreateTuple(Vector3 pos1, Vector3 pos2)
        {
            Tuple<Vector3, Vector3> edge;
            if (pos1.X <= pos2.X && pos1.Y <= pos2.Y)
            {
                edge = new Tuple<Vector3, Vector3>(pos1, pos2);
            }
            else
            {
                edge = new Tuple<Vector3, Vector3>(pos2, pos1);
            }
            return edge; ;
        }

        private void UpdateChildrenLevel(List<ResearchItem> items, string parent, int parentLevel)
        {
            foreach (ResearchItem item in items)
            {
                if (item.PreReqs.Contains(parent))
                {
                    if (item.Level <= parentLevel)
                    {
                        item.Level = parentLevel + 1;
                    }
                }
            }
        }
        public List<ResearchItem> GetAvailableResearchItems()
        {
            List<ResearchItem> filteredItems = new List<ResearchItem>();
            foreach (ResearchItem item in ResearchItems)
            {
                if (item.PreReqs != null && item.IsComplete == false)
                {
                    bool preReqsAreComplete = true;
                    foreach (string prereqItem in item.PreReqs)
                    {
                        //This isn't that efficent. How could we optimize this? 
                        if (ResearchItems.Find(r => r.Name == prereqItem).IsComplete == false)
                        {
                            preReqsAreComplete = false;
                            break;
                        }
                    }
                    if (preReqsAreComplete == true)
                    {
                        filteredItems.Add(item);
                    }
                }
            }
            return filteredItems;
        }

        public List<ResearchItem> GetCompletedResearchItems()
        {
            List<ResearchItem> filteredItems = new List<ResearchItem>();
            foreach (ResearchItem item in ResearchItems)
            {
                if (item.IsComplete)
                {
                    filteredItems.Add(item);
                }
            }
            return filteredItems;
        }

        public List<ResearchItem> GetResearchItemsCurrentlyBeingWorked()
        {
            List<ResearchItem> filteredItems = new List<ResearchItem>();
            foreach (ResearchItem item in ResearchItems)
            {
                if (item.WorkersAssigned > 0)
                {
                    filteredItems.Add(item);
                }
            }
            return filteredItems;
        }

        public ResearchItem FindItem(List<ResearchItem> items, string name)
        {
            foreach (ResearchItem item in items)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        //public void LoadResearchItems(List<ResearchItem> researchItems)
        //{

        //}

        //public void SetPositions(List<ResearchItem> researchItems)
        //{
        //    decimal width = 1.618m;
        //    decimal height = 1m;

        //    foreach (ResearchItem item in researchItems)
        //    {

        //    }
        //}

        private bool ValidateItems(List<ResearchItem> items)
        {
            Dictionary<string, int> itemChecker = new Dictionary<string, int>();
            //Add each item to a dictonary, checking that the list is unique
            foreach (ResearchItem item in items)
            {
                if (itemChecker.ContainsKey(item.Name))
                {
                    //itemChecker[item.Name]++;
                    throw new System.Exception("Item '" + item.Name + "' exists more than once");
                }
                else
                {
                    itemChecker.Add(item.Name, 1);
                }
            }
            //Check that each pre-req exists in the dictonary
            foreach (ResearchItem item in items)
            {
                foreach (string prereq in item.PreReqs)
                {
                    if (!itemChecker.ContainsKey(prereq))
                    {
                        throw new System.Exception("Child '" + prereq + "' not found");
                    }
                }
            }
            return true;
        }

        private void AssignLevels(List<ResearchItem> items,
            int itemWidth, int itemHeight)
        {
            foreach (ResearchItem item in items)
            {
                //First find the level 1 items (no prereqs)
                if (item.PreReqs.Count == 0)
                {
                    item.Level = 1;
                }
                //Then for each level 1 item, find it's child, and increment the level
                UpdateChildrenLevel(items, item.Name, item.Level);

                //Assign a standard height and width to every item
                item.Width = itemWidth;
                item.Height = itemHeight;
            }
        }
    }
}
