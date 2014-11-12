namespace Defining_Classes_Part_II
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    
    public class GenericList<T>
    {
        private const int InitialSize = 16;
        private T[] elements;
        private int count=0;
       
        
        public GenericList(int capacity)           
        {
            this.elements = new T[capacity];
            
        }

        public void Add(T element)
        {
            if (count>=elements.Length)
	        {
		         GrowCapacity();
	        }
            this.elements[count] = element;
            this.count++;
        }

        private void GrowCapacity()
        {
            T[] temp = new T[elements.Length * 2];
            Array.Copy(elements, 0, temp, 0, elements.Length);
            elements = temp;
        }

        
        public void Remove(T element)
        {
            int index = Array.IndexOf(elements, element);
            T[] tempArray = (T[])elements.Clone();
            elements = new T[tempArray.Length];
            Array.Copy(tempArray, index + 1, elements, index, elements.Length - index - 1);
            count--; 
        }

        public void Insert(int position,T element)
        {
            if (count == elements.Length)
            {
                GrowCapacity();
            }
            Array.Copy(elements, position, elements, position + 1, elements.Length - position - 1);
            elements[position] = element;
            count++;
        }

        public void Clear()
        {
            int length;
            length = elements.Length;
            elements = new T[length];
        }

        public int Find(T point)
        {
            int index = Array.IndexOf(elements, point);
            return index;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(elements[i] + " ");
            }
            return result.ToString();
        }
        public T Min<T>() where T : IComparable<T>,IComparable
        {
            dynamic min = elements.Min();
            return min;
        }
        public T Max<T>() where T : IComparable<T>, IComparable
        {
            dynamic max = elements.Max();
            return max;
        }
    }
}
