namespace ConsoleRPG.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleRPG.Interfaces;
    using ConsoleRPG.Enums;
    using System.Threading;

    public class Player : GameObject, IRenderable, IMoveable
    {
        private Coordinates topLeftCoordinates;
        private List<Homework> homeworks;
        private List<Knowledge> knowledge;
        private List<EquiptableItem> rewards;
        private int selectedItem;

        private decimal time;
        private decimal timeModdifierAmmount;

        public Player(string name, Coordinates topLeftCoordinates) : base(name)
        {
            this.TopLeftCoordinates = topLeftCoordinates;

            this.homeworks = new List<Homework>();
            this.rewards = new List<EquiptableItem>();
            this.Time = 0;
            this.timeModdifierAmmount = 1;
            this.selectedItem = 0;

            InitializePlayerKnowledge();
        }

        public int RewardsCount
        {
            get
            {
                return this.rewards.Count;
            }
        }

        public decimal TimeModdifierAmmount
        {
            get
            {
                return this.timeModdifierAmmount;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.timeModdifierAmmount = value;
            }
        }

        public decimal Time
        {
            get
            {
                return this.time;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeDecimals(value);
                this.time = value * (1 - this.timeModdifierAmmount);
            }
        }

        private void InitializePlayerKnowledge()
        {
            this.knowledge = new List<Knowledge>();

            var typesOfKnowledge = Enum.GetValues(typeof(KnowledgeTypes));

            int knowledgeTypeIndexCounter = 0;

            foreach (var knowledge in typesOfKnowledge)
            {
                this.knowledge.Add(new Knowledge(knowledge.ToString(), (KnowledgeTypes)knowledgeTypeIndexCounter, 0, 1));
                knowledgeTypeIndexCounter++;
            }
        }

        public Coordinates ColisionCoords
        {
            get
            {
                return this.TopLeftCoordinates + new Coordinates(1, 1);
            }
        }

        public List<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
        }

        public Coordinates TopLeftCoordinates
        {
            get
            {
                return this.topLeftCoordinates;
            }
            set
            {
                this.topLeftCoordinates = value;
            }
        }

        public List<Knowledge> Knowledge
        {
            get
            {
                return this.knowledge;
            }
        }

        public string[] GetImage()
        {
            return new string[] { " O ", "(|)", "/ \\" };
        }

        public RenderColorType GetRenderColorType()
        {
            return RenderColorType.Cyan;
        }

        public void GetReward(EquiptableItem reward)
        {
            this.rewards.Add(reward);
        }

        public void TransferRewardsToStash(Stash stash)
        {
            foreach (var reward in this.rewards)
            {
                stash.AddItem(reward);
            }

            this.rewards.Clear();
        }

        public void OpenStatus(Keyboard keyboard)
        {
            this.selectedItem = 0;
            List<string> statuses = new List<string>();

            List<string> statusDetails = new List<string>();

            statuses.Add("Name");
            statusDetails.Add(this.Name);

            statuses.Add("Time wasted");
            statusDetails.Add(this.Time.ToString());

            statuses.Add("Knowledge:");
            statusDetails.Add("---------------");

            foreach (var knowledge in this.Knowledge)
            {
                statuses.Add(knowledge.Name);
                statusDetails.Add(knowledge.Ammount + " / " + knowledge.Moddifier);
            }

            statuses.Add("Homeworks To solve:");
            statusDetails.Add(this.homeworks.Count.ToString());

            statuses.Add("Rewards");
            statusDetails.Add("---------------");

            foreach (var item in this.rewards)
            {
                statuses.Add(item.Name);
                statusDetails.Add(item.Description[0]);
            }

            while (keyboard.PressedKey.Key != ConsoleKey.Enter)
            {
                keyboard.ProcessInput();
                MenuRenderer.RenderMenu(statuses.ToArray(), statusDetails.ToArray(),
                    this.selectedItem, 10, 20);
                Thread.Sleep(100);
            }

            this.selectedItem = 0;

            MenuRenderer.ClearScreen();
        }

        public void OpenQuests(Keyboard keyboard)
        {
            this.selectedItem = 0;
            int homeworksToDisplay = Math.Min(10, this.Homeworks.Count);

            if (homeworksToDisplay == 0)
            {
                MenuRenderer.OpenInnerMenuWithText("no homeworks items yet", this.TopLeftCoordinates);
                return;
            }

            List<string> homeworkItems = new List<string>();

            for (int i = 0; i < homeworksToDisplay; i++)
            {
                homeworkItems.Add(this.Homeworks[i].Name);
            }

            while (keyboard.PressedKey.Key != ConsoleKey.Enter)
            {
                MenuRenderer.RenderMenu(homeworkItems.ToArray(), this.Homeworks[selectedItem].Description,
                    this.selectedItem, 10, 20);
                Thread.Sleep(100);
            }

            if (this.homeworks[selectedItem].TrySolve(this))
            {
                MenuRenderer.OpenInnerMenuWithText("Homeworks solved!", this.TopLeftCoordinates);
            }
            else
            {
                MenuRenderer.OpenInnerMenuWithText("Not enough knowledge", this.TopLeftCoordinates);
            }

            this.selectedItem = 0;

            MenuRenderer.ClearScreen();
        }

        public void OpenItems(Keyboard keyboard)
        {
            this.selectedItem = 0;
            int rewardsToDisplay = Math.Min(10, this.rewards.Count);

            if (rewardsToDisplay==0)
            {
                MenuRenderer.OpenInnerMenuWithText("no reward items yet",this.TopLeftCoordinates);
                return;
            }

            List<string> rewardItems = new List<string>();

            for (int i = 0; i < rewardsToDisplay; i++)
            {
                rewardItems.Add(this.rewards[i].Name);
            }

            while (keyboard.PressedKey.Key != ConsoleKey.Enter)
            {
                keyboard.ProcessInput();
                MenuRenderer.RenderMenu(rewardItems.ToArray(), this.rewards[selectedItem].Description,
                    this.selectedItem, 10, 20);
                Thread.Sleep(100);
            }

            this.selectedItem = 0;

            MenuRenderer.ClearScreen();
        }

        #region move
        
        public void MoveUp()
        {
            this.selectedItem++;
            if (this.TopLeftCoordinates.X - 1 > 0)
            {
                this.TopLeftCoordinates += new Coordinates(-1, 0);
            }
        }
        
        public void MoveDown()
        {
            this.selectedItem--;
            if (this.TopLeftCoordinates.X + 1 < Constants.WINDOW_HEIGHT - this.GetImage()[0].Length)
            {
                this.TopLeftCoordinates += new Coordinates(1, 0);
            }
        }
        
        public void MoveLeft()
        {
            if (this.TopLeftCoordinates.Y - 1 > 0)
            {
                this.TopLeftCoordinates += new Coordinates(0, -1);
            }
        }
        
        public void MoveRight()
        {
            if (this.TopLeftCoordinates.Y < Constants.WINDOW_WIDTH - this.GetImage()[0].Length)
            {
                this.TopLeftCoordinates += new Coordinates(0, 1);
            }
        }
    
        #endregion
    }
}