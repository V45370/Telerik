using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public interface IComments
    {
        List<string> Comments { get; set; }
        void AddComment(string comment);
    }
}