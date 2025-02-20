class NegativeGoal : Goal
{
    public NegativeGoal(string name, int points)
    {
        Name = name;
        Points = -points; // Negative points
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetProgress()
    {
        return "[⚠] Avoid this!";
    }
}
