namespace ConsoleRPG
{
    using System;

    //singleton :)
    public static class RandomInstance
    {
        private static Random instance;

        public static Random Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Random();
                }

                return instance;
            }
        }
    }
}