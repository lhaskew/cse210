using System;

class Program
{
    static void Main()
    {
        Address lectureAddress = new Address("1020 W Main St", "Boise", "ID", "83702");
        Event lecture = new Lecture("Environmental Sustainability Conference", "A conference on sustainable practices and innovations", "2024-09-20", "10:00 AM", lectureAddress, "Dr. Sarah Johnson", 150);

        Address receptionAddress = new Address("3133 S Apple St", "Boise", "ID", "83706");
        Event reception = new Reception("Tech Innovators Meetup", "A networking event for tech professionals and entrepreneurs", "2024-11-05", "06:00 PM", receptionAddress, "rsvp@techinnovators.com");

        Address outdoorAddress = new Address("101 Fort St", "Boise", "ID", "83712");
        Event outdoor = new OutdoorGathering("Fall Harvest Festival", "An outdoor festival celebrating the fall harvest with local vendors and activities", "2024-10-15", "01:00 PM", outdoorAddress, "Partly cloudy");

        Event[] events = { lecture, reception, outdoor };

        foreach (var ev in events)
        {
            Console.WriteLine("Standard Details:\n" + ev.GetStandardDetails());
            Console.WriteLine("\nFull Details:\n" + ev.GetFullDetails());
            Console.WriteLine("\nShort Description:\n" + ev.GetShortDescription());
            Console.WriteLine("\n-----------------------------------\n");
        }
    }
}
