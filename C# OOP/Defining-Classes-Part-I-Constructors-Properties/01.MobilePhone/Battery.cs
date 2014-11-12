
namespace MobilePhone
{
    using System;
    public enum BatteryType
    {
        LiIon,NiMH,NiCd
    }
    public enum ModelType
    {
        HTC,Samsung,Nokia,Blackberry,LG,Sony,Motorola
    }
    
    public class Battery
    {
        //fields
        private BatteryType batteryType;
        private string model;
        private int hoursIdle;
        private int hoursTalk;

        //properties
        public int HoursTalk
        {
            get { return this.hoursTalk; }

            set 
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("HoursTalk must be a positive number.");
                }
                this.hoursTalk = value; 
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

        public int HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("HoursIdle must be a positive number.");
                }
                this.hoursIdle = value; 
            }
        }

        //constructors
        public Battery()
        { 

        }

        public Battery(string model)
        {
            this.model = model;
        }

        public Battery(string model, int hoursIdle,int hoursTalk,BatteryType batteryType):this(model)
        {            
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
        }

       

    }
}
