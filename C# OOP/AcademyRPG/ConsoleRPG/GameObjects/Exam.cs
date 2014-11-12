namespace ConsoleRPG.GameObjects
{
    using System;
    using System.Linq;
    using ConsoleRPG.Interfaces;
    using ConsoleRPG.Enums;

    public class Exam : KnowledgeInteractionItem,ISolveable
    {
        private decimal knowledgeAmmountRequired;
        private int numberOfHomeworksRequired;

        public Exam(string name, KnowledgeTypes type, decimal ammountRequired, uint numberOfHomeworksRequired) 
            : base (name,type)
        {
            this.KnowledgeAmmountRequired = ammountRequired;
            this.NumberOfHomeworksRequired = (int)numberOfHomeworksRequired;
            this.Solved = false;
        }

        public int NumberOfHomeworksRequired
        {
            get
            {
                return this.numberOfHomeworksRequired;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeInts(value);
                this.numberOfHomeworksRequired = value;
            }
        }

        public decimal KnowledgeAmmountRequired
        {
            get
            {
                return this.knowledgeAmmountRequired;
            }
            private set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.knowledgeAmmountRequired = value;
            }
        }

        public bool Solved { get; set; }

        public bool TrySolve(Player player)
        {
            foreach (var knowledge in player.Knowledge)
            {
                if (this.Type == knowledge.Type)
                {
                    if (this.KnowledgeAmmountRequired <= knowledge.Ammount)
                    {
                        this.Solved = true;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
