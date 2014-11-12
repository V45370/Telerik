using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;


public class ArithmeticalExpression
{
    
    public static List<char> arithmeticOperations = new List<char>() { '+', '-', '*', '/' };
    public static List<char> brackets = new List<char>() { '(',')' };
    public static List<string> functions = new List<string>() { "pow", "ln", "sqrt" };

    public static List<string> SeparateTokens(string input)
    {
        var result = new List<string>();

        var number = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i]=='-' && (i==0 || input[i-1]==',' || input[i-1]=='('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(input[i]) || input[i]=='.')
            {
                number.Append(input[i]);
            }
            else if(!char.IsDigit(input[i]) && input[i]!='.' &&  number.Length !=0)
            {
                result.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (brackets.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (arithmeticOperations.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (input[i] == ',')
            {
                result.Add(",");
            }
            else if (i + 1 < input.Length && input.Substring(i, 2).ToLower() == "ln")
            {
                result.Add("ln");
                i++;
            }
            else if (i + 1 < input.Length && input.Substring(i, 3).ToLower() == "pow")
            {
                result.Add("pow");
                i += 2;
            }
            else if (i + 1 < input.Length && input.Substring(i, 4).ToLower() == "sqrt")
            {
                result.Add("sqrt");
                i += 3;
            }
            else
            {
                throw new ArgumentException("Invalid expression");
            }
            
        }
        if (number.Length!=0)
        {
            result.Add(number.ToString());
        }
        return result;
    }
    public static int Precedence(string arithmeticOperator)
    {
    if (arithmeticOperator == "+" || arithmeticOperator=="-")
	    {
            return 1;
		 
	    }
    else
	    {
            return 2;
	    }
    }

    public static string ConvertToReversePolishNotation(List<string> tokens)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();
        
        for (int i = 0; i < tokens.Count; i++)
        {
            string currentOperator = stack.Pop();
            var currentToken = tokens[i];
            double number;
            if (double.TryParse(currentToken,out number))
            {
                queue.Enqueue(number.ToString());
            }
            else if (functions.Contains(currentToken))
	        {
                stack.Push(currentToken);
	        }
           
            else if (currentToken==",")
	        {
                if (!stack.Contains("(") || stack.Count == 0)
                {
		                    throw new ArgumentException("Invalid brackes or functions separator");
	            }


                while (stack.Peek() != "(")
	            {
                            
	                   
                    queue.Enqueue(stack.Pop());

	            }
                 
                 
            }
            else if (arithmeticOperations.Contains(currentToken[0]))
            {
                while(stack.Count!=0 && arithmeticOperations.Contains(stack.Peek()[0]) &&  Precedence(currentToken) <= Precedence(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());

                }
                stack.Push(currentToken);
            }
            else if (currentToken=="(")
	        {
		        stack.Push("(");
	        }
            else if (currentToken==")" || stack.Count == 0)
	        {
		        if (!stack.Contains("("))
	            {
		            throw new ArgumentException (" Invalid brackers position");
	            }
                while (stack.Peek() !="(")
	            {
	                queue.Enqueue(stack.Pop());
	            }
                stack.Pop();
                if (stack.Count()!= 0 && functions.Contains(stack.Peek()))
	            {
		            queue.Enqueue(stack.Pop());
	            }
	        }

	    
        }
        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Invalid brackets position");
            }
            queue.Enqueue(stack.Pop());
        }
        return queue;
    }

    public static void PutInvariantCulture()
    {
        //Thread
    }
    public static double GetResultFromRPN(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();
        while(queue.Count!=0)
        {
            double number;
            string currentToken = queue.Dequeue();
            if (double.TryParse(currentToken,out number))
            {
                stack.Push(number);
            }
            else if(arithmeticOperations.Contains(currentToken[0]) || functions.Contains(currentToken))
	        {
                if (currentToken=="-")
	            {
                    if (stack.Count<2)
	                {
                        throw new ArgumentException("Invalid expression");
		 
	                }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue-firstValue);
		 
	            }
                if (currentToken=="+")
	            {
                    if (stack.Count<2)
	                {
                        throw new ArgumentException("Invalid expression");
		 
	                }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue+secondValue);
		 
	            }
                if (currentToken=="*")
	            {
                    if (stack.Count<2)
	                {
                        throw new ArgumentException("Invalid expression");
		 
	                }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue*secondValue);
		 
	            }
                if (currentToken=="/")
	            {
                    if (stack.Count<2)
	                {
                        throw new ArgumentException("Invalid expression");
		 
	                }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue/firstValue);
		 
	            }

                if (currentToken == "pow")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");

                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(Math.Pow(secondValue,firstValue));

                }
                if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");

                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(Math.Sqrt(number));

                }
                if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");

                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(Math.Log(number));

                }


	        }


        }
        if (stack.Count==1)
        {
            return stack.Pop();
        }
        else
        {
            throw new ArgumentException("Invalid expression");

        }
    }
    static void Main()
    {
        
        string input = Console.ReadLine().Trim();
        string trimmedInput = input.Replace(" ",string.Empty);

        var separatedTokens = SeparateTokens(trimmedInput);
        var reversePolishNotation = ConvertToReversePolishNotation(separatedTokens);
        var finalResult = GetResultFromRPN(reversePolishNotation);
        Console.WriteLine(finalResult);
    }
}