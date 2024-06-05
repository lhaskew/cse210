using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2024, 6, 3), 30, 3.0),
            new Cycling(new DateTime(2024, 6, 4), 45, 15.0),
            new Swimming(new DateTime(2024, 6, 5), 60, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
