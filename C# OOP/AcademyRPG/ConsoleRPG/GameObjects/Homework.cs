namespace ConsoleRPG.GameObjects
{
    using System;
    using System.Linq;
    using ConsoleRPG.Interfaces;
    using ConsoleRPG.Enums;

    public class Homework: KnowledgeInteractionItem,ISolveable,IInteractable
    {
        private decimal knowledgeAmmountRequired;

        public Homework(string name, KnowledgeTypes type, decimal ammountRequired) 
            : base (name,type)
        {
            this.KnowledgeAmmountRequired = ammountRequired;
            this.Solved = false;
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

        public string[] Description
        {
            get
            {
                return new string[] {string.Format("KnowledgeCost: {0}",this.KnowledgeAmmountRequired)
                                        ,string.Format("Type: {0}",base.Type.ToString())};
            }
        }
    }
}
