namespace ConsoleRPG
{
    using System;
    using System.Collections.Generic;

    //all Exceptions are handled here
    public static class DataValidiryChecker
    {
        public static void CheckString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new AcademyRPGException(string.Format("{0} can not be null or empty!",
                    value.GetType().ReflectedType.Name));
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                throw new AcademyRPGException(string.Format("{0} can not be null or white spaces",
                    value.GetType().ReflectedType.Name));
            }
            else if (value.Length < 2)
            {
                throw new AcademyRPGException(string.Format("{0} can not be less than 2 characters!",
                    value.GetType().ReflectedType.Name));
            }
        }
        
        public static void CheckForNonNegativeInts(int value)
        {
            if (value < 0)
            {
                throw new AcademyRPGException(string.Format("{0}'s coordinates can not be less than 0!",
                    value.GetType().ReflectedType.Name));
            }
        }

        public static void CheckForCharsOnlyNumbersAndLetters(char value)
        {
            if (!char.IsLetterOrDigit(value))
            {
                throw new AcademyRPGException(string.Format("{0}'s char can be only letter or digit!",
                    value.GetType().ReflectedType.Name));
            }
        }

        public static void CheckForNonNegativeDecimals(decimal value)
        {
            if (value < 0)
            {
                throw new AcademyRPGException(string.Format("{0}'s knowledge ammount or moddifier can not be less than 0!",
                    value.GetType().ReflectedType.Name));
            }
        }

        public static void CheckNullObjects(object obj)
        {
            if (obj == null)
            {
                throw new AcademyRPGException(string.Format("{0} can not be null!",
                    obj.GetType().ReflectedType.Name));
            }
        }

        public static void CheckEmptyIEnumerable(IEnumerable<object> ienum)
        {
            bool flag = true;
            foreach (var item in ienum)
            {
                flag = false;
                break;
            }
            if (flag)
            {
                throw new AcademyRPGException(string.Format("{0} collection can not be empty!",
                    ienum.GetType().ReflectedType.Name));
            }
        }
    }
}
