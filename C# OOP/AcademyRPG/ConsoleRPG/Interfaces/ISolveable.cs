namespace ConsoleRPG.Interfaces
{
    using GameObjects;
    using System.Collections.Generic;
    using ConsoleRPG.Enums;

    //adds to the list of CollectableItemsACurrentItem
    public interface ISolveable
    {
        KnowledgeTypes Type { get; }

        decimal KnowledgeAmmountRequired { get; }

        bool Solved { get; set; }

        bool TrySolve(Player player);
    }
}
