
using System.Collections.Generic;

namespace ResearchTree.Models
{
    public static class ResearchPool
    {
        public static List<ResearchItem> BuildDemoList(bool reset = false)
        {
            List<ResearchItem> items = new List<ResearchItem>()
            {
                ResearchPool.CreateA(reset),
                ResearchPool.CreateB(reset),
                ResearchPool.CreateC(reset),
                ResearchPool.CreateD(reset),
                ResearchPool.CreateE(reset),
                ResearchPool.CreateF(reset),
                ResearchPool.CreateG(reset),
                ResearchPool.CreateH(reset),
                //ResearchPool.CreateI(),
                //ResearchPool.CreateJ(),
                //ResearchPool.CreateK()
            };
            return items;
        }

        public static ResearchItem CreateA(bool reset = false)
        {
            if (reset == true)
            {
                return new ResearchItem()
                {
                    Name = "A",
                    PreReqs = new List<string>(),
                    WorkToComplete = 1,
                    WorkersAssigned = 1
                };
            }
            else
            {
                return new ResearchItem()
                {
                    Name = "A",
                    PreReqs = new List<string>(),
                    WorkToComplete = 1,
                    WorkCompleted = 1,
                    IsComplete = true
                };
            }
        }

        public static ResearchItem CreateB(bool reset = false)
        {
            if (reset == true)
            {
                return new ResearchItem()
                {
                    Name = "B",
                    PreReqs = { "A" },
                    WorkToComplete = 5
                };
            }
            else
            {
                return new ResearchItem()
                {
                    Name = "B",
                    PreReqs = { "A" },
                    WorkToComplete = 5,
                    WorkCompleted = 5,
                    IsComplete = true
                };
            }
        }

        public static ResearchItem CreateC(bool reset = false)
        {
            if (reset == true)
            {
                return new ResearchItem()
                {
                    Name = "C",
                    PreReqs = { "A" },
                    WorkToComplete = 20
                };
            }
            else
            {
                return new ResearchItem()
                {
                    Name = "C",
                    PreReqs = { "A" },
                    WorkToComplete = 20,
                    WorkCompleted = 3,
                    WorkersAssigned = 1,
                    IsComplete = false
                };
            }
        }

        public static ResearchItem CreateD(bool reset = false)
        {
            if (reset == true)
            {
                return new ResearchItem()
                {
                    Name = "D",
                    PreReqs = { "A" },
                    WorkToComplete = 3
                };
            }
            else
            {
                return new ResearchItem()
                {
                    Name = "D",
                    PreReqs = { "A" },
                    WorkToComplete = 3,
                    WorkCompleted = 3,
                    IsComplete = true
                };
            }
        }

        public static ResearchItem CreateE(bool reset = false)
        {
            if (reset == true)
            {
                return new ResearchItem()
                {
                    Name = "E",
                    PreReqs = { "B", "C" },
                    WorkToComplete = 50
                };
            }
            else
            {
                return new ResearchItem()
                {
                    Name = "E",
                    PreReqs = { "B", "C" },
                    WorkToComplete = 50,
                    WorkCompleted = 0,
                    IsComplete = false
                };
            }
        }

        public static ResearchItem CreateF(bool reset = false)
        {
            if (reset == true)
            {
                return new ResearchItem()
                {
                    Name = "F",
                    PreReqs = { "E" },
                    WorkToComplete = 50
                };
            }
            else
            {
                return new ResearchItem()
                {
                    Name = "F",
                    PreReqs = { "E" },
                    WorkToComplete = 50,
                    WorkCompleted = 0,
                    IsComplete = false
                };
            }
        }

        public static ResearchItem CreateG(bool reset = false)
        {
            if (reset == true)
            {
                return new ResearchItem()
                {
                    Name = "G",
                    PreReqs = { "E" },
                    WorkToComplete = 100
                };
            }
            else
            {
                return new ResearchItem()
                {
                    Name = "G",
                    PreReqs = { "E" },
                    WorkToComplete = 100,
                    WorkCompleted = 0,
                    IsComplete = false
                };
            }
        }

        public static ResearchItem CreateH(bool reset = false)
        {
            if (reset == true)
            {
                return new ResearchItem()
                {
                    Name = "H",
                    PreReqs = { "G", "D" },
                    WorkToComplete = 100
                };
            }
            else
            {
                return new ResearchItem()
                {
                    Name = "H",
                    PreReqs = { "G", "D" },
                    WorkToComplete = 100,
                    WorkCompleted = 0,
                    IsComplete = false
                };
            }
        }

        //public static ResearchItem CreateI()
        //{
        //    return new ResearchItem()
        //    {
        //        Name = "I",
        //        PreReqs = { "D" },
        //        WorkToComplete = 3,
        //        WorkCompleted = 0,
        //        IsComplete = false
        //    };
        //}

        //public static ResearchItem CreateJ()
        //{
        //    return new ResearchItem()
        //    {
        //        Name = "J",
        //        PreReqs = { "K","G" },
        //        WorkToComplete = 3,
        //        WorkCompleted = 0,
        //        IsComplete = false
        //    };
        //}

        //public static ResearchItem CreateK()
        //{
        //    return new ResearchItem()
        //    {
        //        Name = "K",
        //        PreReqs = { "A" },
        //        WorkToComplete = 3,
        //        WorkCompleted = 0,
        //        IsComplete = false
        //    };
        //}

    }
}