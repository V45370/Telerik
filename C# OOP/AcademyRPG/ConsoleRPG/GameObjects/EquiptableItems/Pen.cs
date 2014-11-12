namespace ConsoleRPG.GameObjects
{
    using ConsoleRPG.Enums;
    using System;

    public class Pen : EquiptableItem
    {
        public Pen(string name, uint price, ItemLevel level)
            : base(name, level, price * 0.25m, 0, EquiptableItemType.Pen) { }
    }
}