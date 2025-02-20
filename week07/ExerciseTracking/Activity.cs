using System;

abstract class Activity
{
    private DateTime date;
    private int duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public int GetDuration() => duration;
    public DateTime GetDate() => date;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy} {this.GetType().Name} ({duration} min): Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}
