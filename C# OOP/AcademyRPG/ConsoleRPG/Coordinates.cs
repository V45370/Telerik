namespace ConsoleRPG
{
    using System;

    public struct Coordinates
    {
        private int x;
        private int y;

        public Coordinates(int x, int y) : this()
        {
            this.x = x;
            this.y = y;
        }

        public Coordinates(Coordinates coords) : this(coords.X, coords.Y)
        {
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeInts(value);
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeInts(value);
                this.y = value;
            }
        }

        public static Coordinates operator +(Coordinates lhs, Coordinates rhs)
        {
            return new Coordinates(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Coordinates operator -(Coordinates lhs, Coordinates rhs)
        {
            return new Coordinates(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static bool operator==(Coordinates lhs, Coordinates rhs)
        {
            return lhs.X == rhs.x && lhs.Y == rhs.Y;
        }

        public static bool operator!=(Coordinates lhs, Coordinates rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.x ^ this.y;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", this.x, this.y);
        }
    }
}