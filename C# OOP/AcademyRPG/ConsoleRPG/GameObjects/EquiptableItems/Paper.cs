namespace ConsoleRPG.GameObjects
{
    using ConsoleRPG.Enums;
    using System;

    public class Paper : EquiptableItem
    {
        public Paper(string name, uint sheets, ItemLevel level)
            : base(name, level, sheets * 0.5m, 0, EquiptableItemType.Paper) { }
    }
}