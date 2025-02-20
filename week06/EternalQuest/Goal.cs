abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public abstract int RecordEvent();
    public abstract string GetProgress();
}
