/*
EXCEEDING REQUIREMENTS:
- Added advanced breathing animation (expanding + easing effect).
- Added full color theme (cyan/green for breathing, yellow prompts, magenta titles, colored menu).
- Added new Mantra Meditation Activity with ordered affirmations.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = -1;

        while (choice != 5)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("-----------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Mantra Meditation Activity");
            Console.WriteLine("5. Quit\n");
            Console.ResetColor();

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Press Enter to continue.");
                Console.ReadLine();
                continue;
            }

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case 1: activity = new BreathingActivity(); break;
                case 2: activity = new ReflectionActivity(); break;
                case 3: activity = new ListingActivity(); break;
                case 4: activity = new MantraMeditationActivity(); break;
                case 5:
                    Console.WriteLine("\nThank you for using the Mindfulness Program!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }
    }
}