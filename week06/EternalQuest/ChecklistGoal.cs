public class ChecklistGoal : Goal
{
    private int _target;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(
        string name, string description, int points, int bonus, int target, int completed = 0, bool isComplete = false)
        : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _completed = completed;
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
            return 0;

        _completed++;
        if (_completed >= _target)
        {
            _isComplete = true;
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override string GetStatusString() =>
        _isComplete ? $"[X] Completed {_completed}/{_target}" : $"[ ] Completed {_completed}/{_target}";

    public override string GetSaveString() =>
        $"ChecklistGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_target}|{_completed}|{_isComplete}";
}