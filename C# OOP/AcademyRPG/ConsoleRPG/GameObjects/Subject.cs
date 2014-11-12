namespace ConsoleRPG.GameObjects
{
    using System;
    using System.Collections.Generic;
    using ConsoleRPG.Enums;

    public class Subject : KnowledgeInteractionItem
    {
        private List<Homework> homeworks;
        private List<Lecture> lectures;
        private List<Presentation> presentations;

        private Exam exam;

        public Subject(string name, List<Homework> homeworks, List<Lecture> lectures, List<Presentation> presentations,
            Exam exam, KnowledgeTypes type)
            :base (name,type)
        {
            this.homeworks = homeworks;
            this.lectures = lectures;
            this.presentations = presentations;
            this.exam = exam;

            this.homeworkIndex = 0;
            this.lectureIndex = 0;
            this.presentationIndex = 0;
        }

        public int homeworkIndex { get; private set; }
        public int lectureIndex { get; private set; }
        public int presentationIndex { get; private set; }

        public Exam Exam
        {
            get
            {
                return this.exam;
            }
            private set
            {
                DataValidiryChecker.CheckNullObjects(value);
                this.exam = value;
            }
        }

        public List<Presentation> Presentations
        {
            get
            {
                return this.presentations;
            }
            private set
            {
                DataValidiryChecker.CheckEmptyIEnumerable(value);
                this.presentations = value;
            }
        }

        public List<Lecture> Lectures
        {
            get
            {
                return this.lectures;
            }
            private set
            {
                DataValidiryChecker.CheckEmptyIEnumerable(value);
                this.lectures = value;
            }
        }

        public List<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            private set
            {
                DataValidiryChecker.CheckEmptyIEnumerable(value);
                this.homeworks = value;
            }
        }
    }
}
