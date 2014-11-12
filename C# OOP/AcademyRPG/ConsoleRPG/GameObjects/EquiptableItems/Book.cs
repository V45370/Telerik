namespace ConsoleRPG.GameObjects
{
    using ConsoleRPG.Enums;
    using System;

    public class Book : EquiptableItem
    {
        public Book(string name, uint pages, ItemLevel level)
            : base(name, level, pages * 2, 0, EquiptableItemType.Book) { }
    }
}