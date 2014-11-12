

namespace Defining_Classes_Part_II
{
    using System.Collections.Generic;

    public class Path
    {
        public List<Point3D> sequenceOfPoints { get;private set; }
        public Path()
        {
            this.sequenceOfPoints = new List<Point3D>();
        }
        public List<Point3D> SequenceOfPoints
        {
            get
            {
                return this.sequenceOfPoints;
            }
            
        }
        public void AddPoint(Point3D point)
        {
            this.sequenceOfPoints.Add(point);
        }
        public void RemovePoint(Point3D point)
        {
            this.sequenceOfPoints.Remove(point);
        }
        
    }
}
