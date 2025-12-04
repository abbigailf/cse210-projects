public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }
        return 0;
    }

    public override string GetStatusString() => _isComplete ? "[X]" : "[ ]";

    public override string GetSaveString() =>
        $"SimpleGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
}