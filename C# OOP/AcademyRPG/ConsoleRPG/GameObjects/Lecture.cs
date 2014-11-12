namespace ConsoleRPG.GameObjects
{
    using System;
    using System.Linq;
    using ConsoleRPG.Interfaces;
    using ConsoleRPG.Enums;

    public class Lecture : KnowledgeInteractionItem, ILearnable
    {
        private decimal hours;
        private decimal knowledgeGainAmmountPerHour;

        public Lecture(string name, decimal knowledgeGainAmmountPerHour,
            decimal hours, KnowledgeTypes type) : base(name,type)
        {
            this.hours = hours;
            this.knowledgeGainAmmountPerHour = knowledgeGainAmmountPerHour;
        }

        public bool Learned { get; set; }

        public decimal KnowledgeAmmountProvided
        {
            get
            {
                return this.knowledgeGainAmmountPerHour * this.hours;
            }
            private set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.knowledgeGainAmmountPerHour = value;
            }
        }

        public decimal TimeRequired
        {
            get
            {
                return this.hours;
            }
            private set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.hours = value;
            }
        }


        public void Learn(Player player)
        {
            foreach (var knowledge in player.Knowledge)
            {
                if (knowledge.Type == this.Type)
                {
                    knowledge.Ammount += this.KnowledgeAmmountProvided;
                    this.Learned = true;
                    player.Time += this.TimeRequired;
                }
            }
        }
    }
}