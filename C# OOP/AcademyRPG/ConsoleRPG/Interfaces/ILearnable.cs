namespace ConsoleRPG.Interfaces
{
    using ConsoleRPG.GameObjects;
    using ConsoleRPG.Enums;

    public interface ILearnable
    {
        decimal TimeRequired { get; }

        decimal KnowledgeAmmountProvided { get; }

        KnowledgeTypes Type { get; }

        bool Learned { get; set; }

        void Learn(Player player);
    }
}
