class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
    {
        Name = name;
        Points = points;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount == _targetCount)
        {
            return Points + _bonusPoints;
        }
        return Points;
    }

    public override string GetProgress()
    {
        return $"[{_currentCount}/{_targetCount}] Completed";
    }
}
