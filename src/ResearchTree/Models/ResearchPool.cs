
namespace ResearchTree.Models
{
    public static class ResearchPool
    {
        public static ResearchItem CreateBronzeWorking()
        {
            return new ResearchItem()
            {
                Name = "Bronze Working",
                ResearchPrereq = null,
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
                ResearchPrereq = CreateBronzeWorking(),
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
                ResearchPrereq = CreateIronWorking(),
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
                ResearchPrereq = CreateSteelWorking(),
                WorkToComplete = 100,
                WorkCompleted = 0,
                IsComplete = false
            };
        }

    }
}