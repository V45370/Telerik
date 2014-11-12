namespace ConsoleRPG.GameObjects
{
    using System;
    using ConsoleRPG.Enums;
    using ConsoleRPG.Interfaces;
    using System.Collections.Generic;
    using System.Threading;

    public class NakovNPC : GameObject,IRenderable,ICollidable,IMoveable
    {
        private List<Riddle> riddles;
        private List<EquiptableItem> rewardItems;
        private int selectedItem;

        public NakovNPC(string name,Coordinates topLeftCoordinates,
            List<Riddle> riddles, List<EquiptableItem> rewardItems)
            :base(name)
        {
            this.riddles = riddles;
            this.TopLeftCoordinates = topLeftCoordinates;
            this.Interacting = false;
            this.selectedItem = 0;

            this.rewardItems = rewardItems;
        }

        public Coordinates TopLeftCoordinates { get; private set; }

        public bool Interacting { get; set; }

        public string[] GetImage()
        {
            return new string[] { "O   O", "  ^  ", this.Name };
        }

        public RenderColorType GetRenderColorType()
        {
            return RenderColorType.White;
        }

        public Coordinates ColisionCoordinates
        {
            get
            {
                return this.TopLeftCoordinates + new Coordinates(1, 1);
            }
        }

        public void RespondToCollision(Player player, Keyboard keyboard)
        {
            this.Interacting = true;

            MenuRenderer.OpenInnerMenuWithText("Select an riddle with ENTER",player.TopLeftCoordinates);
            MenuRenderer.OpenInnerMenuWithText("    Press Key For Answer   ",player.TopLeftCoordinates);

            string[] itemsToDraw = GetAllRiddlesNames();

            while (keyboard.PressedKey.Key != ConsoleKey.Enter)
            {
                keyboard.ProcessInput();
                MenuRenderer.RenderMenu(itemsToDraw, this.riddles[selectedItem].Description, this.selectedItem, 10, 20);
                Thread.Sleep(100);
            }

            char answer = (Console.ReadKey().KeyChar);
            if (this.riddles[selectedItem].TrySolve(answer))
            {
                player.GetReward(this.rewardItems[RandomInstance.Instance.Next(0, this.rewardItems.Count)]);
            }

            MenuRenderer.OpenInnerMenuWithText("Reward Item Added To Your stash!", player.TopLeftCoordinates);

            player.MoveDown();

            this.selectedItem = 0;

            this.Interacting = false;
        }

        private string[] GetAllRiddlesNames()
        {
            List<string> nameBuilder = new List<string>();

            int counter = 0;

            foreach (var riddle in this.riddles)
            {
                if (!riddle.Solved)
                {
                    counter++;
                    nameBuilder.Add(string.Format("Riddle {0}", counter));
                }
            }

            return nameBuilder.ToArray();
        }

        public void MoveRight()
        {
            //nope
        }

        public void MoveLeft()
        {
            //nope
        }

        public void MoveUp()
        {
            this.selectedItem--;
            if (selectedItem < 0)
            {
                this.selectedItem = 0;
            }
        }

        public void MoveDown()
        {
            this.selectedItem++;
            if (selectedItem >= this.riddles.Count)
            {
                this.selectedItem = this.riddles.Count - 1;
            }
        }
    }
}
