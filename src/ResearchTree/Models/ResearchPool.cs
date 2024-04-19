using System.Collections.Generic;

namespace ResearchTree.Models
{
    public static class ResearchPool
    {
        public static List<ResearchItem> BuildDemoList()
        {
            List<ResearchItem> items = new List<ResearchItem>()
            {
                CreateA(),
                CreateB(),
                CreateC(),
                CreateD(),
                CreateE(),
                CreateF(),
                CreateG(),
                CreateH()
            };
            return items;
        }

        public static ResearchItem CreateA()
        {
            return new ResearchItem()
            {
                Name = "A",
                PreReqs = new List<string>(),
                CostToComplete = 5,
                WorkCompleted = 0,
                WorkersAssigned = 1
            };
        }

        public static ResearchItem CreateB()
        {
            return new ResearchItem()
            {
                Name = "B",
                PreReqs = { "A" },
                CostToComplete = 5,
                WorkCompleted = 0
            };
        }

        public static ResearchItem CreateC()
        {
            return new ResearchItem()
            {
                Name = "C",
                PreReqs = { "A" },
                CostToComplete = 5,
                WorkCompleted = 0
            };
        }

        public static ResearchItem CreateD()
        {
            return new ResearchItem()
            {
                Name = "D",
                PreReqs = { "A" },
                CostToComplete = 5,
                WorkCompleted = 0
            };
        }

        public static ResearchItem CreateE()
        {
            return new ResearchItem()
            {
                Name = "E",
                PreReqs = { "B", "C" },
                CostToComplete = 5,
                WorkCompleted = 0
            };
        }

        public static ResearchItem CreateF()
        {
            return new ResearchItem()
            {
                Name = "F",
                PreReqs = { "E" },
                CostToComplete = 5,
                WorkCompleted = 0
            };
        }

        public static ResearchItem CreateG()
        {
            return new ResearchItem()
            {
                Name = "G",
                PreReqs = { "E" },
                CostToComplete = 5,
                WorkCompleted = 0
            };
        }

        public static ResearchItem CreateH()
        {
            return new ResearchItem()
            {
                Name = "H",
                PreReqs = { "G", "D" },
                CostToComplete = 5,
                WorkCompleted = 0
            };
        }

    }
}