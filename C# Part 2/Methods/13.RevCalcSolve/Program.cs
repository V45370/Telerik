using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Tasks
{
    //Write a program that can solve these tasks:
    //Reverses the digits of a number
    //Calculates the average of a sequence of integers
    //Solves a linear equation a * x + b = 0
    //Create appropriate methods.
    //Provide a simple text-based menu for the user to choose which task to solve.
    //Validate the input data:
    //    The decimal number should be non-negative
    //    The sequence should not be empty
    //    a should not be equal to 0

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your choice:");
        Console.WriteLine("1 - Reverse digits of a number.");
        Console.WriteLine("2 - Calculate average of a sequence of integers.");
        Console.WriteLine("3 - Solve a linear equation a*x + b = 0.");
        byte choice = byte.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter a number");
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    Console.WriteLine("Please enter a positive number");

                }
                else
                {
                    ReverseDigits(number);
                }
                break;
            case 2:
                Console.WriteLine("Enter size of the set:");
                int size = int.Parse(Console.ReadLine());
                if (size == 0)
                {
                    Console.WriteLine("The set of numbers should not be empty.");

                }
                else
                {
                    int[] setOfNumbers = new int[size];
                    for (int i = 0; i < setOfNumbers.Length; i++)
                    {
                        setOfNumbers[i] = int.Parse(Console.ReadLine());
                    }
                    CalcAverage(setOfNumbers);

                }
                break;
            case 3:
                Console.WriteLine("Enter a:");
                int a = int.Parse(Console.ReadLine());
                if (a == 0)
                {
                    Console.WriteLine("a should not be 0");
                }
                else
                {
                    Console.WriteLine("Enter b:");
                    int b = int.Parse(Console.ReadLine());
                    SolveLinear(a, b);
                }
                break;
            default:
                Console.WriteLine("Enter 1, 2 or 3.");
                break;

        }
    }
    static void ReverseDigits(int number)
    {
        string numberAsString = number.ToString();
        char[] arrayOfDigits = numberAsString.ToCharArray();
        Array.Reverse(arrayOfDigits);
        Console.WriteLine("Reversed number:");
        for (int i = 0; i < arrayOfDigits.Length; i++)
        {
            Console.Write(arrayOfDigits[i] + " ");
        }
        Console.WriteLine();

    }
    static void CalcAverage(int[] setOfNumbers)
    {
        decimal sum = 0;
        decimal average = 0;

        foreach (int element in setOfNumbers)
        {
            sum += element;
            average = sum / setOfNumbers.Length;
        }
        Console.WriteLine("Average is {0}", average);

    }

    static void SolveLinear(decimal a, decimal b)
    {
        decimal x = (-b) / a;
        Console.WriteLine("x = {0}", x);
    }

}