namespace MobilePhone
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        //fields
        private string model;       
        private string manufacturer;
        private uint price;        
        private string owner;
        private static GSM iPhone4S=new GSM("Iphone 4S", "Apple",1000,"Anonymous");

         
        //properties
        private List<Call> CallHistory { get; set; }  
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model cant be null or empty");
                }             
 
                this.model = value;
               
            }
            
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Manufacturer cant be null or empty");
                }  
                this.manufacturer = value; 
            }
        }
        public uint Price
        {
            get { return this.price; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentNullException("Price cant be less than 0");
                } 
                this.price = value;
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Owner cant be null or empty");
                } 
                this.owner = value;
            }
        }

        
        //construnctors
        public GSM()
        { 

        }
        

        public GSM(string model, string manufacturer)            
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, uint price, string owner) : this(model,manufacturer)
        {  
            this.price = price;
            this.owner = owner;
        }
        
        //override ToString() method
        public override string ToString()
        {
            return "Name: " + this.model + "\nManufacturer: " + this.manufacturer + "\nPrice: " + this.price +  "\nOwner: " + this.owner;
        }




        public void AddCall(Call newCall)
        {
            this.CallHistory.Add(newCall);
        }
        public void DeleteCall(Call myCall) // remove given call
        {
            this.CallHistory.Remove(myCall);
        }
        public void DeleteCall(int index) // remove at given index
        {
            this.CallHistory.RemoveAt(index);
        }
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }
        public List<Call> GetCallHistory()
        {
            return this.CallHistory;
        }

        public float CalculateTotalPrice(float pricePerMinute)
        {
            float totalPrice = 0;
             foreach (var call in CallHistory)
            {
                totalPrice += call.Duration * pricePerMinute / 60;
            }
            return totalPrice;
        }      
        
    }
}
