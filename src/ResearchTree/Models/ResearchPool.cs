
using System.Collections.Generic;

namespace ResearchTree.Models
{
    public static class ResearchPool
    {
        public static ResearchItem CreateBasicMining()
        {
            return new ResearchItem()
            {
                Name = "Basic Mining",
                PreReqs = new List<string>(),
                WorkToComplete = 1,
                WorkCompleted = 1,
                IsComplete = true
            };
        }

        public static ResearchItem CreateBronzeWorking()
        {
            return new ResearchItem()
            {
                Name = "Bronze Working",
                PreReqs = { "Basic Mining" },
                WorkToComplete = 5,
                WorkCompleted = 5,
                IsComplete = true
            };
        }

        public static ResearchItem CreateIronWorking()
        {
            return new ResearchItem()
            {
                Name = "Iron Working",
                PreReqs = { "Bronze Working" },
                WorkToComplete = 20,
                WorkCompleted = 3,
                IsComplete = false
            };
        }

        public static ResearchItem CreateSteelWorking()
        {
            return new ResearchItem()
            {
                Name = "Steel Working",
                PreReqs = { "Iron Working" },
                WorkToComplete = 50,
                WorkCompleted = 0,
                IsComplete = false
            };
        }

        public static ResearchItem CreateAdvancedMining()
        {
            return new ResearchItem()
            {
                Name = "Advanced Mining",
                PreReqs = { "Steel Working" },
                WorkToComplete = 50,
                WorkCompleted = 0,
                IsComplete = false
            };
        }

        public static ResearchItem CreateTitaniumWorking()
        {
            return new ResearchItem()
            {
                Name = "Titanium Working",
                PreReqs = {
                    "Advanced Mining",
                    "Steel Working"
                },
                WorkToComplete = 100,
                WorkCompleted = 0,
                IsComplete = false
            };
        }

    }
}