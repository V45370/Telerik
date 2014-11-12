namespace ConsoleRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleRPG.Enums;
    using ConsoleRPG.GameObjects;
    using ConsoleRPG.GameObjects.MapObjects;

    public static class GameObjectsInitializer
    {
        public static Player GeneratePlayer()
        {
            return new Player("Player", Constants.initialPlayerCoordinates);
        }

        public static Stash GenerateStash()
        {
            return new Stash("Stash", Constants.StashCoordinates);
        }

        public static Map GenerateMap()
        {
            return new Map(Constants.WINDOW_HEIGHT,Constants.WINDOW_WIDTH);
        }

        #region NPC
        public static List<Npc> GenerateNPCs()
        {
            List<Npc> npcToReturn = new List<Npc>();

            var ivayloSubjects = GenerateIvayloSubjects();
            var donchoSubjects = GenerateDonchoSubjects();
            var nikiSubjects = GenerateNikiSubjects();

            Npc Ivaylo = new Npc("Ivaylo", Constants.IvayloCoordinates, ivayloSubjects);
            Npc Donchno = new Npc("Doncho", Constants.DonchoCoordinates, donchoSubjects);
            Npc Niki = new Npc("Niki", Constants.NikiCoordinates, nikiSubjects);

            npcToReturn.Add(Ivaylo);
            npcToReturn.Add(Donchno);
            npcToReturn.Add(Niki);

            return npcToReturn;
        }

        private static List<Subject> GenerateIvayloSubjects()
        {
            List<Subject> subjectsToReturn = new List<Subject>();

            Subject CSharp1 = GenerateSubjectItem("C#1", KnowledgeTypes.DesktopAndMobile, 6, 6, 6, 5, 10, 1, 1, 2, 3, 1, 0.04m, 25);
            Subject CSharp2 = GenerateSubjectItem("C#2", KnowledgeTypes.DesktopAndMobile, 6, 6, 6, 5, 20, 5, 1, 2, 3, 1, 0.04m, 25);
            Subject OOP = GenerateSubjectItem("OOP", KnowledgeTypes.DesktopAndMobile, 6, 6, 6, 5, 10, 30, 10, 2, 3, 1, 0.04m, 25);

            subjectsToReturn.Add(CSharp1);
            subjectsToReturn.Add(CSharp2);
            subjectsToReturn.Add(OOP);

            return subjectsToReturn;
        }

        private static List<Subject> GenerateDonchoSubjects()
        {
            List<Subject> subjectsToReturn = new List<Subject>();

            Subject HTML = GenerateSubjectItem("HTML", KnowledgeTypes.WebDevelopment, 6, 6, 6, 5, 10, 1, 1, 2, 3, 1, 0.04m, 25);
            Subject CSS = GenerateSubjectItem("CSS", KnowledgeTypes.WebDevelopment, 6, 6, 6, 5, 20, 5, 1, 2, 3, 1, 0.04m, 25);
            Subject JS = GenerateSubjectItem("JavaScript", KnowledgeTypes.WebDevelopment, 6, 6, 6, 5, 30, 10, 1, 2, 3, 1, 0.04m, 25);

            subjectsToReturn.Add(HTML);
            subjectsToReturn.Add(CSS);
            subjectsToReturn.Add(JS);

            return subjectsToReturn;
        }

        private static List<Subject> GenerateNikiSubjects()
        {
            List<Subject> subjectsToReturn = new List<Subject>();

            Subject KPK = GenerateSubjectItem("KPK", KnowledgeTypes.QualityAssurance, 6, 6, 6, 5, 10, 1, 1, 2, 3, 1, 0.04m, 25);
            Subject QA1 = GenerateSubjectItem("QA1", KnowledgeTypes.QualityAssurance, 6, 6, 6, 5, 20, 5, 1, 2, 3, 1, 0.04m, 25);
            Subject QA2 = GenerateSubjectItem("QA2", KnowledgeTypes.QualityAssurance, 6, 6, 6, 5, 30, 10, 1, 2, 3, 1, 0.04m, 25);

            subjectsToReturn.Add(KPK);
            subjectsToReturn.Add(QA1);
            subjectsToReturn.Add(QA2);

            return subjectsToReturn;
        }

        private static Subject GenerateSubjectItem(string name, KnowledgeTypes type,
            uint numberOfHomeworks, uint numberOfLectures, uint numberOfPresentations,
            uint examHomeworksRequired, uint examKnowledgerequired,
            decimal firstHomeworkReqKnowledge, decimal homeworkIncreazeReqKnowledge,
            decimal lecturesKnowledgeGainPerHour, decimal lectureHours,
            decimal presentationKnowledgeGain, decimal timeRequiredPerSlide, uint numberOfSlides)
        {
            List<Homework> homeworks = new List<Homework>();
            for (int i = 0; i < numberOfHomeworks; i++)
            {
                homeworks.Add(new Homework(string.Format("{0}Homework{1}", name, i + 1), type,
                    firstHomeworkReqKnowledge + i * homeworkIncreazeReqKnowledge));
            }

            List<Lecture> lectures = new List<Lecture>();
            for (int i = 0; i < numberOfLectures; i++)
            {
                lectures.Add(new Lecture(string.Format("{0}Lecture{1}", name, i + 1),
                    lecturesKnowledgeGainPerHour, lectureHours, type));
            }

            List<Presentation> presentations = new List<Presentation>();
            for (int i = 0; i < numberOfPresentations; i++)
            {
                presentations.Add(new Presentation(string.Format("{0}Presentation{1}", name, i + 1),
                    timeRequiredPerSlide, presentationKnowledgeGain, numberOfSlides, type));
            }

            Exam exam = new Exam(string.Format("{0}Exam", name), type, examKnowledgerequired, examHomeworksRequired);

            return new Subject(name, homeworks, lectures, presentations, exam, type);
        }
        #endregion

        #region Nakov

        public static NakovNPC GenerateNakov()
        {
            var riddles = GenerateRiddles();
            var rewards = GenerateRiddleRewards();

            return new NakovNPC("Nakov", Constants.NakovCoordinates, riddles, rewards);
        }

        private static List<Riddle> GenerateRiddles()
        {
            List<Riddle> riddlesToReturn = new List<Riddle>();

            riddlesToReturn.Add(new Riddle("Riddle 1", "How many bits does a byte contain?", '8'));
            riddlesToReturn.Add(new Riddle("Riddle 2", "2*4-7+3=?", '4'));
            riddlesToReturn.Add(new Riddle("Riddle 3", "(20+7-3)/8=?", '3'));
            riddlesToReturn.Add(new Riddle("Riddle 4", "Binary to Decimal: 111", '7'));
            riddlesToReturn.Add(new Riddle("Riddle 5", "6/2*3-4=?", '5'));
            riddlesToReturn.Add(new Riddle("Riddle 6", "What is the last digit in 2^10?", '4'));

            return riddlesToReturn;
        }

        private static List<EquiptableItem> GenerateRiddleRewards()
        {
            List<EquiptableItem> rewardsToReturn = new List<EquiptableItem>();

            rewardsToReturn.Add(new Book("C#1", 400, ItemLevel.Basic));
            rewardsToReturn.Add(new Book("C#2", 400, ItemLevel.Basic));
            rewardsToReturn.Add(new Book("C#1", 600, ItemLevel.Advanced));
            rewardsToReturn.Add(new Book("C#2", 600, ItemLevel.Advanced));
            rewardsToReturn.Add(new Book("OOP", 800, ItemLevel.Expert));

            rewardsToReturn.Add(new Laptop("Asus1",1,0.01m, ItemLevel.Basic));
            rewardsToReturn.Add(new Laptop("Lenovo1", 2,0.01m, ItemLevel.Basic));
            rewardsToReturn.Add(new Laptop("Asus2", 2, 0.02m, ItemLevel.Advanced));
            rewardsToReturn.Add(new Laptop("Lenovo2", 2, 0.02m, ItemLevel.Advanced));
            rewardsToReturn.Add(new Laptop("Alienware", 4, 0.02m, ItemLevel.Expert));

            rewardsToReturn.Add(new Paper("A6", 10, ItemLevel.Basic));
            rewardsToReturn.Add(new Paper("A5", 20, ItemLevel.Basic));
            rewardsToReturn.Add(new Paper("A4", 20, ItemLevel.Advanced));
            rewardsToReturn.Add(new Paper("A3", 30, ItemLevel.Advanced));
            rewardsToReturn.Add(new Paper("A1", 50, ItemLevel.Expert));

            rewardsToReturn.Add(new Pen("simple pen", 100, ItemLevel.Basic));
            rewardsToReturn.Add(new Pen("smart pen", 150, ItemLevel.Basic));
            rewardsToReturn.Add(new Pen("fancy pen", 150, ItemLevel.Advanced));
            rewardsToReturn.Add(new Pen("extra pen", 200, ItemLevel.Advanced));
            rewardsToReturn.Add(new Pen("the grandfather", 250, ItemLevel.Expert));

            return rewardsToReturn;
        }
        #endregion
    }
}
