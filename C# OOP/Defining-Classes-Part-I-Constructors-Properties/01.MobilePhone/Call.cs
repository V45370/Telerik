namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    public class Call
    {
        private readonly DateTime dateTime = new DateTime();
        private string DialedPhoneNumber { get; set; }
        private int duration; // in seconds 
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }
        }
        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("Duration cant be negative");
                }         
                this.duration = value;
            }

        }

        public Call(): this("Private number", 0)
        {
        }
        public Call(string dialedPhoneNumber, int duration)
        {
            this.dateTime = DateTime.Now;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.Duration = duration;
        }
        public override string ToString()
        {
            return ("Date: " + this.dateTime.ToShortDateString() + " Time: " + this.dateTime.ToShortTimeString() +
                " Dialed Number: " + this.DialedPhoneNumber + " Duration: " + this.Duration + " sec");
        }
    }
}
