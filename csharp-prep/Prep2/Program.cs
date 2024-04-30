using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        string letter;

        if (gradePercentage >= 90)
            letter = "A";
        else if (gradePercentage >= 80)
            letter = "B";
        else if (gradePercentage >= 70)
            letter = "C";
        else if (gradePercentage >= 60)
            letter = "D";
        else
            letter = "F";

        bool passed = gradePercentage >= 70;

        Console.WriteLine($"Your letter grade is: {letter}");

        if (passed)
            Console.WriteLine("Congratulations, you passed the course!");
        else
            Console.WriteLine("Don't worry, keep working hard for next time!");
    }
}
