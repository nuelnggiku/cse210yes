
using System;

public class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual TimeSpan GetPace()
    {
        return new TimeSpan(0, 0, 0);
    }

    public virtual string GetSummary()
    {
        return $"{_date.ToShortDateString()} - {_length} min";
    }
}

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / (_length / 60.0);
    }

    public override TimeSpan GetPace()
    {
        int minutesPerMile = (int)(_length / _distance);
        int secondsPerMile = (int)((_length / _distance - minutesPerMile) * 60);
        return new TimeSpan(0, minutesPerMile, secondsPerMile);
    }

    public override string GetSummary()
    {
        double distance = Math.Round(_distance, 1);
        double speed = Math.Round(GetSpeed(), 1);
        TimeSpan pace = GetPace();
        return $"{base.GetSummary()} Running ({_length} min) - Distance {distance} miles, Speed {speed} mph, Pace: {pace.Minutes}:{pace.Seconds:D2} min per mile";
    }
}

public class StationaryBicycle : Activity
{
    private double _speed;

    public StationaryBicycle(DateTime date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (_length / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override TimeSpan GetPace()
    {
        double distanceInKm = GetDistance() * 1.61;
        int minutesPerKm = (int)(_length / distanceInKm);
        int secondsPerKm = (int)((_length / distanceInKm - minutesPerKm) * 60);
        return new TimeSpan(0, minutesPerKm, secondsPerKm);
    }

    public override string GetSummary()
    {
        double distance = Math.Round(GetDistance(), 1);
        double speed = Math.Round(_speed, 1);
        TimeSpan pace = GetPace();
        return $"{base.GetSummary()} Stationary Bicycle ({_length} min) - Distance {distance} km, Speed {speed} kph, Pace: {pace.Minutes}:{pace.Seconds:D2} min per km";
    }
}

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (_length / 60.0);
    }

    public override TimeSpan GetPace()
    {
        double paceInMinutesPerKm = _length / (GetDistance() * 1.61);
        int minutesPer100m = (int)(paceInMinutesPerKm / 16.1 * 60);
        int secondsPer100m = (int)((paceInMinutesPerKm / 16.1 - minutesPer100m / 60.0) * 60 * 100);
        return new TimeSpan(0, 0, minutesPer100m, secondsPer100m);
    }

    public override string GetSummary()
    {
        double distance = Math.Round(GetDistance(), 1);
        double speed = Math.Round(GetSpeed(), 1);
        TimeSpan pace = GetPace();
        return $"{base.GetSummary()} Swimming ({_length} min) - Distance {distance} km, Speed {speed} kph, Pace: {pace.Minutes}:{pace.Seconds:D2} per 100 m";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Activity runningActivity = new Running(new DateTime(2022, 11, 3), 30, 3);
        Console.WriteLine(runningActivity.GetSummary());

        Activity bicycleActivity = new StationaryBicycle(new DateTime(2022, 11, 3), 45, 20);
        Console.WriteLine(bicycleActivity.GetSummary());

        Activity swimmingActivity = new Swimming(new DateTime(2022, 11, 3), 60, 50);
        Console.WriteLine(swimmingActivity.GetSummary());

        Console.ReadLine();

        //This code creates a base Activity class with shared attributes and methods, as well as derived classes for Running, StationaryBicycle, and Swimming activities. It also uses virtual and overridden methods to calculate the distance, speed, and pace of each activity.

//The Main() method creates at least one activity of each type, sets their values, and calls the GetSummary method on each item to generate a summary of the activity. The output is then displayed to the console.
    }
}

