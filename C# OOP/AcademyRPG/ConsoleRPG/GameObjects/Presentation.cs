namespace ConsoleRPG.GameObjects
{
    using System;
    using System.Linq;
    using ConsoleRPG.Interfaces;
    using ConsoleRPG.Enums;

    public class Presentation : KnowledgeInteractionItem, ILearnable
    {
        private readonly int slides;
        private decimal timeRequiredPerSlide;
        private decimal knowledgeGainAmmount;

        public Presentation(string name, decimal timeRequiredPerSlide, decimal knowledgeGainAmmount,
            uint numberOfSlides, KnowledgeTypes type) : base(name,type)
        {
            this.slides = (int)numberOfSlides;
            this.TimeRequired = timeRequiredPerSlide;
            this.KnowledgeAmmountProvided = knowledgeGainAmmount;
        }

        public bool Learned { get; set; }

        public decimal KnowledgeAmmountProvided
        {
            get
            {
                return this.knowledgeGainAmmount;
            }
            private set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.knowledgeGainAmmount = value;
            }
        }

        public decimal TimeRequired
        {
            get
            {
                return this.slides * this.timeRequiredPerSlide;
            }
            private set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.timeRequiredPerSlide = value;
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