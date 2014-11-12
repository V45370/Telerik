namespace ConsoleRPG.GameObjects
{
    using ConsoleRPG.Interfaces;

    public class Riddle : GameObject,IInteractable
    {
        private string question;
        private char answer;

        public Riddle(string name, string question, char answer)
            :base (name)
        {
            this.Question = question;
            this.Answer = answer;
            this.Solved = false;
        }

        public string[] Description
        {
            get
            {
                return new string[] { this.Question };
            }
        }

        public string Question
        {
            get
            {
                return this.question;
            }
            private set
            {
                DataValidiryChecker.CheckString(value);
                this.question = value;
            }
        }

        private char Answer
        {
            set
            {
                DataValidiryChecker.CheckForCharsOnlyNumbersAndLetters(value);
                this.answer = value;
            }
        }

        public bool Solved { get; private set; }

        public bool TrySolve(char answer)
        {
            if (answer == this.answer)
            {
                this.Solved = true;
                return true;
            }
            return false;
        }
    }
}
