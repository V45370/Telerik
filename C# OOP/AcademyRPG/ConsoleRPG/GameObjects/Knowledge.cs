namespace ConsoleRPG.GameObjects
{
    using System;
    using ConsoleRPG.Enums;

    public class Knowledge : GameObject
    {
        private KnowledgeTypes type;
        private decimal ammount;
        private decimal modifier;

        public Knowledge(string name, KnowledgeTypes type, decimal ammount, decimal modifier) : base(name)
        {
            this.Ammount = ammount;
            this.Moddifier = modifier;
            this.type = type;
        }

        public decimal Ammount
        {
            get
            {
                return this.ammount * this.Moddifier;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.ammount = value;
            }
        }

        public decimal Moddifier
        {
            get
            {
                return this.modifier;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.modifier = value;
            }
        }

        public KnowledgeTypes Type
        {
            get
            {
                return this.type;
            }
        }

        public static Knowledge operator +(Knowledge one, Knowledge two)
        {
            return new Knowledge(one.Name,one.Type,one.Ammount + two.Ammount,one.Moddifier);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Name, this.Type.ToString(), this.Ammount, this.Moddifier);
        }
    }
}