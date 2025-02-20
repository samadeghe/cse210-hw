class ProgressGoal : Goal
{
    private int _goalValue;
    private int _currentProgress;

    public ProgressGoal(string name, int points, int goalValue)
    {
        Name = name;
        Points = points;
        _goalValue = goalValue;
        _currentProgress = 0;
    }

    public override int RecordEvent()
    {
        _currentProgress += Points;
        return Points;
    }

    public override string GetProgress()
    {
        return $"Progress: {_currentProgress}/{_goalValue}";
    }
}
