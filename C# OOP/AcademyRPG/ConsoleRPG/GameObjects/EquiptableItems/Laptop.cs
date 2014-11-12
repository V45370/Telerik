namespace ConsoleRPG.GameObjects
{
    using ConsoleRPG.Enums;
    using System;

    public class Laptop : EquiptableItem
    {
        public Laptop(string name, uint numberOfCores, decimal speedPerCore, ItemLevel level)
            : base(name, level, 0, numberOfCores * speedPerCore, EquiptableItemType.Laptop) { }
    }
}