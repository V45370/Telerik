using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class HTMLElement : IElement
    {

        public virtual string Name { get; private set; }
        public virtual string TextContent { get; set; }
        private IList<IElement> elements;

        public HTMLElement(string name)
        {
            this.Name = name;
            this.TextContent = null;
            this.elements = new List<IElement>();
           
        }
        public HTMLElement(string name, string textcontent)
            :this(name)
        {
           
            this.TextContent = textcontent;
            
        }


        public IEnumerable<IElement> ChildElements
        {
            get { return this.elements; }
        }

        public void AddElement(IElement element)
        {
            this.elements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append("<");
                output.Append(this.Name);
                output.Append(">");
            }
            if (this.TextContent != null)
            {
                output.Append(this.TextContent);
            }
            foreach (var element in this.elements)
            {
                element.Render(output);
            }
            if (this.Name != null)
            {
                output.Append("</");
                output.Append(this.Name);
                output.Append(">");
            }
        
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            this.Render(result);
            return result.ToString();
        }
        
    }
}
