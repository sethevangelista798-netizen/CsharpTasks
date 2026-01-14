using System;

class Task4
{
    static void Main()
    {
        string continueChoice = "Y";
        
        // While loop to repeat the program
        while (continueChoice.ToUpper() == "Y")
        {
            // Display menu
            Console.WriteLine("Press any following key to perform an arithmetic operation:");
            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Multiplication");
            Console.WriteLine("4 - Division");
            
            // Get user's operation choice
            int operation = int.Parse(Console.ReadLine());
            
            // Get two values from user
            Console.Write("Enter Value 1: ");
            double value1 = double.Parse(Console.ReadLine());
            
            Console.Write("Enter Value 2: ");
            double value2 = double.Parse(Console.ReadLine());
            
            double result = 0;
            string operatorSymbol = "";
            
            // Switch-case to select operation
            switch (operation)
            {
                case 1:
                    result = Addition(value1, value2);
                    operatorSymbol = "+";
                    break;
                case 2:
                    result = Subtraction(value1, value2);
                    operatorSymbol = "-";
                    break;
                case 3:
                    result = Multiplication(value1, value2);
                    operatorSymbol = "*";
                    break;
                case 4:
                    result = Division(value1, value2);
                    operatorSymbol = "/";
                    break;
                default:
                    Console.WriteLine("Invalid operation choice!");
                    continue;
            }
            
            // Display result in specified format
            Console.WriteLine($"{value1} {operatorSymbol} {value2} = {result}");
            
            // Ask if user wants to continue
            Console.Write("Do you want to continue again (Y/N)? ");
            continueChoice = Console.ReadLine();
            Console.WriteLine();
        }
    }
    
    // Separate method for Addition
    static double Addition(double a, double b)
    {
        return a + b;
    }
    
    // Separate method for Subtraction
    static double Subtraction(double a, double b)
    {
        return a - b;
    }
    
    // Separate method for Multiplication
    static double Multiplication(double a, double b)
    {
        return a * b;
    }
    
    // Separate method for Division
    static double Division(double a, double b)
    {
        return a / b;
    }
}