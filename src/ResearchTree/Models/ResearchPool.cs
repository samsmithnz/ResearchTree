
using System.Collections.Generic;

namespace ResearchTree.Models
{
    public static class ResearchPool
    {
        public static ResearchItem CreateA()
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

        public static ResearchItem CreateB()
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

        public static ResearchItem CreateC()
        {
            return new ResearchItem()
            {
                Name = "C",
                PreReqs = { "A" },
                WorkToComplete = 20,
                WorkCompleted = 3,
                IsComplete = false
            };
        }

        public static ResearchItem CreateD()
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

        public static ResearchItem CreateE()
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

        public static ResearchItem CreateF()
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

        public static ResearchItem CreateG()
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

        public static ResearchItem CreateH()
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