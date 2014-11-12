namespace ConsoleRPG.GameObjects
{
    using System;
    using ConsoleRPG.Enums;

    public abstract class KnowledgeInteractionItem : GameObject
    {
        private KnowledgeTypes type;

        public KnowledgeInteractionItem(string name, KnowledgeTypes knowledgeType) : base(name)
        {
            this.type = knowledgeType;
        }

        public KnowledgeTypes Type
        {
            get
            {
                return this.type;
            }
        }
    }
}