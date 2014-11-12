
namespace Defining_Classes_Part_II
{
    public struct Point3D 
    {
        //1.Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        //2.Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
        private static readonly Point3D point0 = new Point3D(0, 0, 0);

                
        public Point3D(int x, int y, int z) :this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        //1.Implement the ToString() to enable printing a 3D point.
        public override string ToString()
        {
            return this.X+" "+this.Y+" "+this.Z;
        }

        //2.Add a static property to return the point O.
        public static string Point0
        {
            get
            {
                return point0.ToString();
            }
        }

    }

}
