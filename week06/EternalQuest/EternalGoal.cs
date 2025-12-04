public class EternalGoal : Goal
{
    private int _streak;

    public EternalGoal(string name, string description, int points, int streak = 0)
        : base(name, description, points)
    {
        _streak = streak;
    }

    public override int RecordEvent()
    {
        _streak++;
        int bonus = (_streak % 7 == 0) ? 100 : 0; // streak bonus every 7 completions
        return GetPoints() + bonus;
    }

    public override string GetStatusString() => $"[∞] (Streak: {_streak})";

    public override string GetSaveString() =>
        $"EternalGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_streak}";
}