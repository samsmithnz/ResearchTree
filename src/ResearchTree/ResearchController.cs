using ResearchTree.Models;
using System.Collections.Generic;
using System.Numerics;

namespace ResearchTree
{
    public class ResearchController
    {
        public List<ResearchItem> ResearchItems { get; set; }

        public List<ResearchItem> BuildDemoList()
        {
            List<ResearchItem> list = new List<ResearchItem>()
            {
                ResearchPool.CreateA(),
                ResearchPool.CreateB(),
                ResearchPool.CreateC(),
                ResearchPool.CreateD(),
                ResearchPool.CreateE(),
                ResearchPool.CreateF(),
                ResearchPool.CreateG()
            };

            //Assign levels to each item.     
            foreach (ResearchItem item in list)
            {
                //First find the level 1 items (no prereqs)
                if (item.PreReqs.Count == 0)
                {
                    item.Level = 1;
                }
                //Then for each level 1 item, find it's child, and increment the level
                UpdateChildrenLevel(list, item.Name, item.Level);
            }

           
            //Now assign positions, based on the level and parent.

            //First look at a level - how many items do we have? Center these vertically as appropriate
            Dictionary<int, int> levelCounts = new Dictionary<int, int>();
            foreach (ResearchItem item in list)
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
            int horizontalDistance = list[0].Width / 2;
            int verticalDistance = list[0].Height / 2;
            foreach (ResearchItem item in list)
            {
                //Horizontal locaiton is the width buffer + the width of the item, based on the level
                float x = (horizontalDistance * item.Level) + (item.Width * (item.Level - 1));
                float y = (verticalDistance * levelCounts[item.Level]) + (item.Height * (levelCounts[item.Level] - 1));
                levelCounts[item.Level]--;
                item.Position = new Vector3(x, y, 0f);
            }

            //Finally draw lines between them


            ResearchItems = list;
            return list;
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

        //public void LoadResearchItems(List<ResearchItem> researchItems)
        //{

        //}

        public void SetPositions(List<ResearchItem> researchItems)
        {
            decimal width = 1.618m;
            decimal height = 1m;

            foreach (ResearchItem item in researchItems)
            {

            }
        }

    }
}
