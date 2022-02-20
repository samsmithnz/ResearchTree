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

            //Now look at pre-reqs. How many parents does each item have. Center these vertically as appropriate

            //Now place the squares
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
            foreach (ResearchItem item in items)
            {
                if (item.PreReqs.Count > 0) //item.Name == "H" &&
                {
                    foreach (string prereq in item.PreReqs)
                    {
                        ResearchItem prereqItem = FindItem(items, prereq);
                        int horizontalGap = (int)(item.Location.X - prereqItem.Location.X);
                        if (horizontalGap < 0)
                        {
                            horizontalGap *= -1;
                        }

                        //If the item is at the same Y position, draw a single straight line
                        if (prereqItem.Location.Y == item.Location.Y)
                        {
                            int x1 = (int)prereqItem.Location.X + prereqItem.Width;
                            int y1 = (int)prereqItem.Location.Y + ItemHeightBuffer;
                            item.Edges.Add(new Tuple<Vector3, Vector3>(
                                new Vector3(x1, y1, 0f),
                                new Vector3(x1 + itemWidthBuffer, y1, 0f)
                            ));
                        }
                        else //if (prereqItem.Name == "D")
                        {
                            //We need to add two half horizontal lines, and a vertical line
                            int x1 = (int)prereqItem.Location.X + prereqItem.Width;
                            int y1 = (int)prereqItem.Location.Y + ItemHeightBuffer;
                            item.Edges.Add(new Tuple<Vector3, Vector3>(
                                new Vector3(x1, y1, 0f),
                                new Vector3(item.Location.X - (ItemWidthBuffer / 2), y1, 0f)
                            ));

                            int x2 = (int)item.Location.X - (ItemWidthBuffer / 2);
                            int y2 = (int)item.Location.Y + ItemHeightBuffer;
                            item.Edges.Add(new Tuple<Vector3, Vector3>(
                                new Vector3(x2, y2, 0f),
                                new Vector3(item.Location.X, y2, 0f)
                            ));

                            //int x3 = (int)item.Location.X - (ItemWidthBuffer / 2);
                            //int y3 = (int)prereqItem.Location.Y + ItemHeightBuffer;
                            //int verticalLineHeight = (int)item.Location.Y - (int)prereqItem.Location.Y;
                            //if (prereqItem.Location.Y > item.Location.Y)
                            //{
                            //    verticalLineHeight = (int)prereqItem.Location.Y - (int)item.Location.Y;
                            //}
                            item.Edges.Add(new Tuple<Vector3, Vector3>(
                                new Vector3(item.Location.X - (ItemWidthBuffer / 2), y1, 0f),
                                new Vector3(x2, y2, 0f)
                            ));

                            //Label horizontalLine1 = new();
                            //horizontalLine1.Name = prereqItem.Name + "_Label1";
                            //horizontalLine1.BorderStyle = BorderStyle.FixedSingle;
                            //horizontalLine1.Size = new Size(horizontalGap - prereqItem.Width - (ItemHeightBuffer / 2), 2);
                            //int x1 = (int)prereqItem.Location.X + prereqItem.Width;
                            //int y1 = (int)prereqItem.Location.Y + ItemHeightBuffer;
                            //horizontalLine1.Location = new Point(x1, y1);
                            //this.Controls.Add(horizontalLine1);

                            //Label horizontalLine2 = new();
                            //horizontalLine2.Name = prereqItem.Name + "_Label2";
                            //horizontalLine2.BorderStyle = BorderStyle.FixedSingle;
                            //horizontalLine2.Size = new Size(ItemHeightBuffer / 2, 2);
                            //int x2 = (int)item.Location.X - (ItemHeightBuffer / 2);
                            //int y2 = (int)item.Location.Y + ItemHeightBuffer;
                            //horizontalLine2.Location = new Point(x2, y2);
                            //this.Controls.Add(horizontalLine2);

                            //Label vecticalLine3 = new();
                            //vecticalLine3.Name = prereqItem.Name + "_Label3";
                            //vecticalLine3.BorderStyle = BorderStyle.FixedSingle;
                            //int verticalLineHeight = (int)item.Location.Y - (int)prereqItem.Location.Y;
                            //if (prereqItem.Location.Y > item.Location.Y)
                            //{
                            //    verticalLineHeight = (int)prereqItem.Location.Y - (int)item.Location.Y;
                            //}
                            //vecticalLine3.Size = new Size(2, verticalLineHeight);
                            //int x3 = (int)item.Location.X - (ItemHeightBuffer / 2);
                            //int y3 = (int)prereqItem.Location.Y + ItemHeightBuffer;
                            //if (prereqItem.Location.Y > item.Location.Y)
                            //{
                            //    y3 -= ((int)prereqItem.Location.Y - item.Height) + ItemHeightBuffer;
                            //}
                            //vecticalLine3.Location = new Point(x3, y3);
                            //this.Controls.Add(vecticalLine3);
                        }
                    }
                }
            }

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
