using System;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by guiding your breathing. Allow the calming colors and expanding animation to steady your mind.")
    { }

    public override void Run()
    {
        StartActivity();

        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            ShowBreathGrowth("Breathe in...", 3);
            ShowBreathGrowth("Breathe out...", 3);
        }

        EndActivity();
    }
}