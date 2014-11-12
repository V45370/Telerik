namespace ConsoleRPG.Interfaces
{
    using System.Collections.Generic;
    using ConsoleRPG.Enums;
    using ConsoleRPG.GameObjects;

    //character has a list with equipted items - when we Equip we Remove the type of item from the list of equipted Items
    //for any operations Player must be near his stash
    //when we remove we have to be near the stash
    public interface IEquiptable
    {
        bool Equipted { get; set; }

        EquiptableItemType Type { get; }

        decimal TimeModdifierAmmount { get; }

        decimal KnowledgeModdifierAmmount { get; }
    }
}
