
namespace Defining_Classes_Part_II
{
    using System;
    public static class Distance3D
    {
        //3.Write a static class with a static method to calculate the distance between two points in the 3D space.
        public static double Distance(Point3D point1, Point3D point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) + Math.Pow(point1.Z - point2.Z, 2));
        }


    }
}
