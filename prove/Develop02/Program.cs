using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        EventRecorder recorder = new EventRecorder();
        recorder.RecordEvent();
    }
}

class EventRecorder
{
    public void RecordEvent()
    {
        Console.WriteLine("Welcome to Daily Event Recorder!");

        Console.Write("Enter the date (e.g., YYYY-MM-DD): ");
        string date = Console.ReadLine();

        Event[] events = new Event[3]; // Assuming we record 3 events per day

        for (int i = 0; i < events.Length; i++)
        {
            Console.Write($"Event {i + 1}: ");
            string description = Console.ReadLine();
            events[i] = new Event(date, description);
        }

        SaveEventsToFile(events);
        Console.WriteLine("Events recorded successfully!");
    }

    private void SaveEventsToFile(Event[] events)
    {
        string filePath = "events.txt";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            foreach (Event ev in events)
            {
                writer.WriteLine($"{ev.Date}: {ev.Description}");
            }
        }
    }
}

class Event
{
    public string Date { get; set; }
    public string Description { get; set; }

    public Event(string date, string description)
    {
        Date = date;
        Description = description;
    }
}
