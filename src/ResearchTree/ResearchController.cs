using ResearchTree.Models;
using System.Collections.Generic;

namespace ResearchTree
{
    public class ResearchController
    {
        public List<ResearchItem> ResearchItems { get; set; }

        public List<ResearchItem> GetAvailableResearchItems()
        {
            List<ResearchItem> filteredItems = new List<ResearchItem>();
            foreach (ResearchItem item in ResearchItems)
            {
                if (item.PreReqs != null &&
                    item.IsComplete == false)
                {
                    bool preReqsAreComplete = true;
                    foreach (ResearchItem prereqItem in item.PreReqs)
                    {
                        if (prereqItem.IsComplete == false)
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

    }
}
