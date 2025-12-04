public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, penalty * -1)
    {
    }

    public override int RecordEvent() => GetPoints(); // subtracts points

    public override string GetStatusString() => "[!]";

    public override string GetSaveString() =>
        $"NegativeGoal:{GetName()}|{GetDescription()}|{GetPoints()}";
}