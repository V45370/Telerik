namespace Defining_Classes_Part_II
{
    using System.IO;
    public static class PathStorage
    {
        public static void Save(Path path)
        {
            using (StreamWriter writer = new StreamWriter("save.txt"))
            {
                foreach (var point in path.SequenceOfPoints)
                {                    
                    writer.WriteLine(point.ToString());                    
                }
            }
        }
        public static void Load(Path path)
        {
            using (StreamReader reader = new StreamReader("read.txt"))
            {
                string buffer = reader.ReadLine();
                while(buffer!=null)
                {
                    
                    string[] nums = buffer.Split(' ');
                    Point3D point = new Point3D(int.Parse(nums[0]),int.Parse(nums[1]),int.Parse(nums[2]));
                    path.AddPoint(point);
                    buffer = reader.ReadLine();
                }
            }
        }
    }
}
