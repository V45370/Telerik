namespace ConsoleRPG.GameObjects
{
    public abstract class GameObject
    {
        private string name;

        public GameObject(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                DataValidiryChecker.CheckString(value);
                this.name = value;
            }
        }
    }
}
