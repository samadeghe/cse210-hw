class SimpleGoal : Goal
{
    private bool _isCompleted;
    
    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
        _isCompleted = false;
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            return Points;
        }
        return 0;
    }

    public override string GetProgress()
    {
        return _isCompleted ? "[X] Completed" : "[ ] Not Completed";
    }
}
