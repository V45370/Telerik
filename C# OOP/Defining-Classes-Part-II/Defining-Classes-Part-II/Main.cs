using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes_Part_II
{
    class Main
    {
        static void Main(string[] args)
        {
            
            Point3D point1 = new Point3D(1, 1, 1);
            Point3D point2 = new Point3D(2, 2, 2);
            Point3D point3 = new Point3D(3, 3, 3);
            Point3D point4 = new Point3D(4, 4, 4);
            Point3D point5 = new Point3D(5, 5, 5);
            //Console.WriteLine(point1.ToString());

            // 3.Write a static class with a static method to calculate the distance between two points in the 3D space.
            Console.WriteLine(Distance3D.Distance(point1, point2));

            Path savePoints = new Path();
            Path loadPoints = new Path();


            savePoints.AddPoint(point1);
            savePoints.AddPoint(point2);
            savePoints.AddPoint(point3);
            savePoints.AddPoint(point4);
            savePoints.AddPoint(point5);


            PathStorage.Save(savePoints);
            PathStorage.Load(loadPoints);

            GenericList<Point3D> listOfPoints = new GenericList<Point3D>(10);
             listOfPoints.Add(point1);
            listOfPoints.Add(point2);
            listOfPoints.Add(point3);
            listOfPoints.Add(point4);
            listOfPoints.Remove(point2);//1,3,4
            listOfPoints.Insert(1,point1);//1,1,3,4
           
            listOfPoints.Find(point4);
           // Console.WriteLine(listOfPoints.ToString());
            listOfPoints.Clear();





        }
    }
}
