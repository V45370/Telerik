
using System;



class BankAccount
{
    struct bankUser                           
    {                                           //Look at solution 10.Emplyees. It's analogical.
        public string firstName;
        public string middleName;
        public string lastName;
        public decimal moneyBalance;
        public string bankName;
        public string iban;
        public string bic;
        public string creditcard1;
        public string creditcard2;
        public string creditcard3;
    }

    static void Main()
    {
           
    bankUser anonymous;                         

    anonymous.firstName = "Anonymous";         
    anonymous.middleName = "Anonymousev";
    anonymous.lastName = "Anonymousev";
    anonymous.moneyBalance = 1234567.89M;
    anonymous.bankName = "ProCredit";
    anonymous.iban = "BG01PCB1234123412341234";
    anonymous.bic = "STSABGSF";
    anonymous.creditcard1 = "1234567812341234";
    anonymous.creditcard2 = "1234567812341235";
    anonymous.creditcard3 = "1234567812341236";

    Console.WriteLine("Fristname:{0}",anonymous.firstName);
    Console.WriteLine("Middlename:{0}",anonymous.middleName);
    Console.WriteLine("Lastname:{0}",anonymous.lastName);    
    Console.WriteLine("Money balance:{0}",anonymous.moneyBalance);
    Console.WriteLine("Bank name: {0}",anonymous.bankName);
    Console.WriteLine("IBAN: {0}",anonymous.iban);
    Console.WriteLine("BIC: {0}",anonymous.bic);
    Console.WriteLine("Credit card 1: {0}",anonymous.creditcard1);
    Console.WriteLine("Credit card 2: {0}", anonymous.creditcard2);
    Console.WriteLine("Credit card 3: {0}",anonymous.creditcard3);



    }
}

