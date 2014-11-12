namespace ConsoleRPG.GameObjects
{
    using System;
    using ConsoleRPG.Interfaces;
    using ConsoleRPG.Enums;
    using System.Collections.Generic;
    using System.Threading;

    public class Npc : GameObject, IRenderable, ICollidable,IMoveable
    {
        private List<Subject> subjects;
        private int subjectIndex;
        private int indexLecture;
        private int indexHomework;
        private int indexPresentation;
        private int selectedItem;

        public Npc(string name, Coordinates topLeftCoordinates,List<Subject> subjects) : base(name)
        {
            this.TopLeftCoordinates = topLeftCoordinates;
            this.subjectIndex = 0;
            this.Subjects = subjects;
            this.indexLecture = 0;
            this.indexHomework = 0;
            this.indexPresentation = 0;
            this.selectedItem = 0;
            this.Interacting = false;
        }

        public bool Interacting { get; set; }

        public List<Subject> Subjects
        {
            get
            {
                return this.subjects;
            }
            private set
            {
                DataValidiryChecker.CheckEmptyIEnumerable(value);
                this.subjects = value;
            }
        }

        public Coordinates TopLeftCoordinates {get;private set;}

        public string[] GetImage()
        {
            return new string[] { "O   O", "  ^  ", this.Name };
        }

        public RenderColorType GetRenderColorType()
        {
            return RenderColorType.Red;
        }

        public Coordinates ColisionCoordinates
        {
            get
            {
                return this.TopLeftCoordinates + new Coordinates(0, 1);
            }
        }

        public void RespondToCollision(Player player, Keyboard keyboard)
        {
            this.Interacting = true;

            string[] itemsToDraw = new string[] {"GiveLecture","GivePresentation",
                "GiveLecture And Presentation","GetHomework","SitExam"};

            while (keyboard.PressedKey.Key != ConsoleKey.Enter)
            {
                keyboard.ProcessInput();
                MenuRenderer.RenderMenu(itemsToDraw, null, this.selectedItem, 10, 20);
                Thread.Sleep(100);
            }

            player.MoveDown();

            this.Interacting = false;

            switch (selectedItem)
            {
                case 0: this.GiveLecture(player); break;
                case 1: this.GivePresentation(player); break;
                case 2: this.GiveLectureAndPresentation(player); break;
                case 3: this.GetHomework(player); break;
                case 4: this.SitExam(player); break;
                default: throw new ArgumentException("No such option");
            }

            this.selectedItem = 0;
        }

        private void GiveLecture(Player player)
        {
            if (this.indexLecture == this.Subjects[subjectIndex].Lectures.Count)
	        {
                MenuRenderer.OpenInnerMenuWithText("No More Lectures!", player.TopLeftCoordinates);
                return;
	        }
            this.Subjects[this.subjectIndex].Lectures[indexLecture].Learn(player);

            MenuRenderer.OpenInnerMenuWithText("Lecture learned!", player.TopLeftCoordinates);

            this.indexLecture++;
        }

        private void GivePresentation(Player player)
        {
            if (this.indexPresentation == this.Subjects[subjectIndex].Presentations.Count)
            {
                MenuRenderer.OpenInnerMenuWithText("No More Presentations!", player.TopLeftCoordinates);
                return;
            }

            MenuRenderer.OpenInnerMenuWithText("Presentation Watched!", player.TopLeftCoordinates);

            this.Subjects[this.subjectIndex].Presentations[indexPresentation].Learn(player);
            this.indexPresentation++;
        }

        private void GiveLectureAndPresentation(Player player)
        {
            this.GiveLecture(player);
            this.GivePresentation(player);
        }

        private void GetHomework(Player player)
        {
            if (this.indexHomework == this.Subjects[subjectIndex].Homeworks.Count)
            {
                MenuRenderer.OpenInnerMenuWithText("No more homeworks!",player.TopLeftCoordinates);
                return;
            }
            MenuRenderer.OpenInnerMenuWithText("Homework added to quests!", player.TopLeftCoordinates);

            player.Homeworks.Add(this.Subjects[this.subjectIndex].Homeworks[indexLecture]);
            this.indexHomework++;
        }

        private void SitExam(Player player)
        {
            if (this.indexHomework + 1 < this.Subjects[subjectIndex].Exam.NumberOfHomeworksRequired)
            {
                MenuRenderer.OpenInnerMenuWithText("You have to solve more homeworks!", player.TopLeftCoordinates);
            }
            else if (this.Subjects[subjectIndex].Exam.TrySolve(player))
            {
                this.subjectIndex++;
                if (subjectIndex >= this.Subjects.Count)
                {
                    this.subjectIndex = 0;//enldess training
                }
                MenuRenderer.OpenInnerMenuWithText("Congratulations! Exam passed!",player.TopLeftCoordinates);
                MenuRenderer.OpenInnerMenuWithText("Moving On to the next subject!", player.TopLeftCoordinates);
            }
            else
            {
                MenuRenderer.OpenInnerMenuWithText("Sorry Exam Failed!",player.TopLeftCoordinates);
                MenuRenderer.OpenInnerMenuWithText("Learn more and try again!", player.TopLeftCoordinates);
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
            if (this.selectedItem < 0)
            {
                this.selectedItem = 0;
            }
        }

        public void MoveDown()
        {
            this.selectedItem++;
            if (this.selectedItem >= 5 )
            {
                this.selectedItem = 4;
            }
        }
    }
}