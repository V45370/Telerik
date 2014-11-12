namespace ConsoleRPG.GameObjects
{
    using ConsoleRPG.Enums;
    using ConsoleRPG.Interfaces;
    using System;

    public abstract class EquiptableItem : GameObject, IEquiptable, IInteractable
    {
        private decimal knowledgeModdifierAmmount;
        private decimal timeModdifierAmmount;
        private readonly ItemLevel itemLevel;

        public EquiptableItem(string name,ItemLevel itemlevel, decimal knowledgemoddifier
            , decimal timemoddifier, EquiptableItemType type) : base(name)
        {
            this.itemLevel = itemlevel;
            this.knowledgeModdifierAmmount = knowledgemoddifier;
            this.TimeModdifierAmmount = timemoddifier;
            this.Equipted = false;
            this.Type = type;
        }

        public bool Equipted { get; set; }

        public EquiptableItemType Type { get; private set; }

        public decimal TimeModdifierAmmount
        {
            get
            {
                return this.timeModdifierAmmount*(decimal)itemLevel;
            }
            private set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.timeModdifierAmmount = value;
            }
        }

        public decimal KnowledgeModdifierAmmount
        {
            get
            {
                return this.knowledgeModdifierAmmount * (decimal)itemLevel;
            }
            private set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.knowledgeModdifierAmmount = value;
            }
        }

        public string [] Description
        {
            get 
            {
                return new string[] 
                { 
                    string.Format("Item Level: {0}", itemLevel), 
                    string.Format("+{0:F2}% knowledge",knowledgeModdifierAmmount), 
                    string.Format("+{0:F2}% time",timeModdifierAmmount),
                };
            }
        }
    }
}