using ResearchTree.Models;
using System.Collections.Generic;

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
            //First find the level 1 items (no prereqs)
            foreach (ResearchItem item in list)
            {
                if (item.PreReqs.Count == 0)
                {
                    item.Level = 1;
                }
            }

            //Then for each level 1 item, find it's child, and increment the level
            foreach (ResearchItem item in list)
            {
                if (item.Level >= 1)
                {
                    UpdateChildrenLevel(list, item.Name, item.Level);
                }
            }

            ResearchItems = list;
            return list;
        }

        public void UpdateChildrenLevel(List<ResearchItem> items, string parent, int parentLevel)
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
