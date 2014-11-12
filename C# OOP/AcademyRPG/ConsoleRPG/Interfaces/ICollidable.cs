namespace ConsoleRPG.Interfaces
{
    using System;
    using ConsoleRPG.GameObjects;

    public interface ICollidable
    {
        Coordinates ColisionCoordinates { get; }

        void RespondToCollision(Player player, Keyboard keyboard);

        bool Interacting { get; set; }
    }
}
