using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock: StaticObject,IResource
    {
        protected int Size { get; private set; }

        public ResourceType Type 
        { 
            get 
            { 
                return ResourceType.Stone; 
            } 
        }

        public int Quantity
        {
            get
            {
                return this.HitPoints/2;
            }
        }

        public Rock(int size, Point position)
            : base(position)
        {
            
            this.HitPoints = size;
            this.Size = this.HitPoints/2;
        }
    }
    
}
