
using System;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _zip;

    public Address(string street, string city, string state, string zip)
    {
        _street = street;
        _city = city;
        _state = state;
        _zip = zip;
    }

    public string GetFullAddress()
    {
        return $"{_street}, {_city} {_state} {_zip}";
    }
}

public abstract class Event
{
    private string _title;
    private string _description;
    private DateTime _date;
    private TimeSpan _time;
    private Address _address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string GetStandardDetails()
    {
        return $"{_title}\n{_description}\n{_date.ToShortDateString()} {_time.ToString("hh\\:mm")} - {_time.Add(TimeSpan.FromHours(1)).ToString("hh\\:mm")}\n{_address.GetFullAddress()}";
    }

    public abstract string GetFullDetails();

    public abstract string GetShortDescription();
}

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity) : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Lecture: {_title} ({_date.ToShortDateString()})";
    }
}

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail) : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nRSVP Email: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Reception: {_title} ({_date.ToShortDateString()})";
    }
}

public class OutdoorGathering : Event
{
    private string _weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement) : base(title, description, date, time, address)
    {
        _weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nWeather Statement: {_weatherStatement}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering: {_title} ({_date.ToShortDateString()})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "12345");
        Lecture lecture1 = new Lecture("Intro to AI", "Learn about the basics of artificial intelligence", new DateTime(2023, 6, 1), new TimeSpan(18, 0, 0), address1, "John Smith", 50);
        Console.WriteLine("Standard Details:\n" + lecture1.GetStandardDetails());
        Console.WriteLine("Full Details:\n" + lecture1.GetFullDetails());
        Console.WriteLine("Short Description:\n" + lecture1.GetShortDescription());

        Address address2 = new Address("456 High St", "Anyville", "ON", "A1B 2C3");
        Reception reception1 = new Reception("Summer Mixer", "Join us for a night of networking and fun!", new DateTime(2023, 8, 15), new TimeSpan(19, 0, 0), address2, "rsvp@example.com");
        Console.WriteLine("\nStandard Details:\n" + reception1.GetStandardDetails());
        Console.WriteLine("Full Details:\n" + reception1.GetFullDetails());
        Console.WriteLine("Short Description:\n" + reception1.GetShortDescription());

        Address address3 = new Address("789 Park Ave", "Anyplace", "NY", "10001");
        OutdoorGathering outdoor1 = new OutdoorGathering("Summer Concert Series", "Enjoy live music in the park", new DateTime(2023, 7, 4), new TimeSpan(15, 0, 0), address3, "Event will be cancelled in case of severe weather.");
        Console.WriteLine("\nStandard Details:\n" + outdoor1.GetStandardDetails());
        Console.WriteLine("Full Details:\n" + outdoor1.GetFullDetails());
        Console.WriteLine("Short Description:\n" + outdoor1.GetShortDescription());
        Console.ReadLine();


        //This code creates a base Event class with shared attributes and methods, as well as derived classes for Lecture, Reception, and OutdoorGathering events. It also uses an Address class to store address information.

//The Main() method creates at least one event of each type, sets their values, and calls each of the requested methods to generate marketing messages and output them to the console.
    }
}
