using System;

class ReportCardApp
{
    // Helper method to get valid integer input within range
    static int GetValidInteger(string prompt, int minVal, int maxVal)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value))
            {
                if (value >= minVal && value <= maxVal)
                {
                    return value;
                }
                Console.WriteLine($"Error: Enter a value between {minVal} and {maxVal}!");
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number!");
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Press any key to start...");
        Console.ReadKey(); // Simulate "press any key"
        Console.Clear();

        // Get total number of students (validated)
        int totalStudents = GetValidInteger("Enter Total Students : ", 1, 100);

        // Multi-dimensional array: [studentIndex, dataIndex]
        // Data indices: 0 = Name (string), 1 = English (int), 2 = Math (int), 3 = Computer (int), 4 = Total (int)
        object[,] students = new object[totalStudents, 5];

        // Loop to input student data
        for (int i = 0; i < totalStudents; i++)
        {
            Console.WriteLine("\n*********************************************");
            Console.Write($"Enter Student Name : ");
            students[i, 0] = Console.ReadLine().Trim();

            students[i, 1] = GetValidInteger("Enter English Marks (Out Of 100) : ", 0, 100);
            students[i, 2] = GetValidInteger("Enter Math Marks (Out Of 100) : ", 0, 100);
            students[i, 3] = GetValidInteger("Enter Computer Marks (Out Of 100) : ", 0, 100);

            // Calculate and store total marks
            students[i, 4] = (int)students[i, 1] + (int)students[i, 2] + (int)students[i, 3];
        }

        // Sort students in descending order of total marks (using bubble sort for simplicity)
        for (int i = 0; i < totalStudents - 1; i++)
        {
            for (int j = 0; j < totalStudents - i - 1; j++)
            {
                int totalJ = (int)students[j, 4];
                int totalJ1 = (int)students[j + 1, 4];
                if (totalJ < totalJ1)
                {
                    // Swap entire student records
                    for (int k = 0; k < 5; k++)
                    {
                        object temp = students[j, k];
                        students[j, k] = students[j + 1, k];
                        students[j + 1, k] = temp;
                    }
                }
            }
        }

        // Assign positions (handle ties)
        int[] positions = new int[totalStudents];
        int currentPosition = 1;
        positions[0] = currentPosition;

        for (int i = 1; i < totalStudents; i++)
        {
            int currentTotal = (int)students[i, 4];
            int prevTotal = (int)students[i - 1, 4];

            if (currentTotal < prevTotal)
            {
                currentPosition = i + 1;
            }
            positions[i] = currentPosition;
        }

        // Generate report card output
        Console.WriteLine("\n****************Report Card*******************");
        for (int i = 0; i < totalStudents; i++)
        {
            Console.WriteLine("**************************************");
            Console.WriteLine($"Student Name: {students[i, 0]}, Position: {positions[i]}, Total: {students[i, 4]}/300");
        }
        Console.WriteLine("**************************************");
    }
}
