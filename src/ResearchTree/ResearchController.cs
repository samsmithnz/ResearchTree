using ResearchTree.Models;
using System.Collections.Generic;
using System.Numerics;

namespace ResearchTree
{
    public class ResearchController
    {
        public List<ResearchItem> ResearchItems { get; set; }

        public ResearchController(List<ResearchItem> items, 
            int itemWidth = 100, int itemHeight = 100,
            int itemWidthBuffer = 50, int itemHeightBuffer = 50)
        {
            //Verify that all of the children exist
            Dictionary<string, int> itemChecker = new Dictionary<string, int>();
            foreach (ResearchItem item in items)
            {
                if (itemChecker.ContainsKey(item.Name))
                {
                    itemChecker[item.Name]++;
                }
                else
                {
                    itemChecker.Add(item.Name, 1);
                }
            }
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

            //Assign levels to each item.     
            foreach (ResearchItem item in items)
            {
                //First find the level 1 items (no prereqs)
                if (item.PreReqs.Count == 0)
                {
                    item.Level = 1;
                }
                //Then for each level 1 item, find it's child, and increment the level
                UpdateChildrenLevel(items, item.Name, item.Level);
                item.Width = itemWidth;
                item.Height = itemHeight;
            }


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

            //Now look at pre-reqs. How many parents does each item have. Center these vertically as appropriate

            //Now place the squares
            //TODO: This should be a property. 
            //If we go backwards here, we build the list in the order that it's created
            for (int i = items.Count - 1; i >= 0; i--)
            {
                ResearchItem item = items[i];
                //Horizontal locaiton is the width buffer + the width of the item, based on the level
                float x = (itemWidthBuffer * item.Level) + (item.Width * (item.Level - 1));
                float y = (itemHeightBuffer * levelCounts[item.Level]) + (item.Height * (levelCounts[item.Level] - 1));
                levelCounts[item.Level]--;
                item.Location = new Vector3(x, y, 0f);
            }

            //Finally draw lines between each node

            ResearchItems = items;
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

        public ResearchItem FindItem(string name)
        {
            foreach (ResearchItem item in ResearchItems)
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

    }
}
