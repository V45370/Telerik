
namespace MobilePhone
{
    using System;
    public class Display
    {
        //fields
        private const ushort fullHD=1080;
        private ushort size;        
        private uint numOfColors;

        //properties
        public ushort Size
        {
            get { return this.size; }
            set
            {
                if (value < 0 || value>fullHD)
                {
                    throw new ArgumentOutOfRangeException("Pixels must be in range [0-1080].");
                }
      
                this.size = value; 
            }
        }
        public uint NumOfColors
        {
            get { return this.numOfColors; }
            set {
                if (value<2)
                {
                    throw new ArgumentOutOfRangeException("Colors must be 2 or higher.");
                }

                this.numOfColors = value; }
        }

        //constructors
        public Display()
        {
 
        }
        public Display(ushort size ,uint numOfColors)
        {
            this.size = size;
            this.numOfColors = numOfColors;
        }

    }
}
