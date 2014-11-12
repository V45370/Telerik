using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Program
    {
        static void Main()
        {
            List<Customers> customersList = new List<Customers>();

            customersList.Add(new Human(20, "Pesho", "M"));
            customersList.Add(new Human(100, "Kiro", "M"));


            customersList.Add(new Companies("Kompaniq 1 ET", 1235));
            customersList.Add(new Companies("Kompaniq 2 OOD", 12512));
            customersList.Add(new Companies("Kompaniq 3", 54132));

            
            List<Accounts> accountsList = new List<Accounts>();
            
            accountsList.Add(new DepositAccount(customersList[0], 1500, 0.06m, 10)); // same parameteres to see the diference
            accountsList.Add(new DepositAccount(customersList[1], 2600, 0.1m, 10));
            accountsList.Add(new DepositAccount(customersList[2], 4700, 0.06m, 10));
            accountsList.Add(new LoanAccount(customersList[3], 7800, 0.06m, 10)); //after override
            accountsList.Add(new MortgageAccount(customersList[4], 5900, 0.06m, 10));

            foreach (var account in accountsList)
            {
                Console.WriteLine(account.CalculateInterest());
                account.Deposit(2100);
                if (account is DepositAccount)
                {
                    account.Drow(300);
                    Console.WriteLine("Drowed money");
                }
            }
        }
    }
}