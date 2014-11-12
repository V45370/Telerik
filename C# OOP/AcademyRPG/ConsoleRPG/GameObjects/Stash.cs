namespace ConsoleRPG.GameObjects
{
    using System;
    using System.Collections.Generic;
    using ConsoleRPG.Interfaces;
    using ConsoleRPG.Enums;
    using System.Threading;

    public class Stash : GameObject, IRenderable, ICollidable, IMoveable
    {
        private Coordinates topLeftCoordinates;

        private readonly List<EquiptableItem> stashItems;
        private int selectedItem;

        public Stash(string name, Coordinates topLeftCoords) : base(name)
        {
            this.topLeftCoordinates = topLeftCoords;
            this.stashItems = new List<EquiptableItem>();
            this.Interacting = false;
            this.selectedItem = 0;
        }

        public bool Interacting { get; set; }

        public string[] GetImage()
        {
            return new string[] { "STA", "-S-", "-H-" };
        }

        public Coordinates TopLeftCoordinates
        {
            get
            {
                return this.topLeftCoordinates;
            }
        }

        public RenderColorType GetRenderColorType()
        {
            return RenderColorType.DarkRed;
        }

        public Coordinates ColisionCoordinates
        {
            get
            {
                return this.TopLeftCoordinates + new Coordinates(1, 1);
            }
        }

        public void AddItem(EquiptableItem item)
        {
            this.stashItems.Add(item);
        }

        public void RespondToCollision(Player player, Keyboard keyboard)
        {
            this.Interacting = true;

            if (player.RewardsCount != 0)
            {
                player.TransferRewardsToStash(this);
            }

            if (this.stashItems.Count == 0)
            {
                MenuRenderer.OpenInnerMenuWithText("no stash items yet", this.TopLeftCoordinates);

                player.MoveRight();
                this.Interacting = false;

                return;
            }

            string[] names = this.StashedItemsNames();
            
            MenuRenderer.ClearScreen(10, 20);

            while (keyboard.PressedKey.Key != ConsoleKey.Enter)
            {
                keyboard.ProcessInput();                
                MenuRenderer.RenderMenu(names, this.stashItems[selectedItem].Description, selectedItem, 10, 20);
                Thread.Sleep(100);
            }

            EquipItem();
            
            CheckEquiptedItems(player);

            MenuRenderer.OpenInnerMenuWithText(string.Format("{0} equipted!",
                this.stashItems[selectedItem].Name), player.TopLeftCoordinates);
            
            this.selectedItem = 0;

            player.MoveRight();

            this.Interacting = false;
        }

        private string[] StashedItemsNames()
        {
            string[] names = new string[this.stashItems.Count];

            for (int i = 0; i < this.stashItems.Count; i++)
            {
                names[i] = this.stashItems[i].Name;
            }
            return names;
        }

        private void EquipItem()
        {
            foreach (var item in this.stashItems)
            {
                if (item.Type == this.stashItems[selectedItem].Type)
                {
                    item.Equipted = false;
                }
            }

            this.stashItems[selectedItem].Equipted = true;
        }

        private void CheckEquiptedItems(Player player)
        {
            player.TimeModdifierAmmount = 1;
            foreach (var knowledge in player.Knowledge)
            {
                knowledge.Moddifier = 1;
            }

            foreach (var item in this.stashItems)
            {
                if (item.Equipted)
                {
                    player.TimeModdifierAmmount += item.TimeModdifierAmmount;
                    foreach (var knowledge in player.Knowledge)
                    {
                        knowledge.Moddifier += item.KnowledgeModdifierAmmount;
                    }
                }
            }
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
            if (selectedItem >= this.stashItems.Count)
            {
                this.selectedItem = this.stashItems.Count - 1;
            }
        }
    }
}