class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetProgress()
    {
        return "[∞] Ongoing";
    }
}
