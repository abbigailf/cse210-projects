// ---------------------------------------------------------
// Exceeding Requirements Description
// ---------------------------------------------------------
// 1. Includes a library of multiple scriptures (John 3:16,
//    Proverbs 3:5–6, Philippians 4:13, Helaman 5:12, and 
//    Doctrine and Covenants 1:37–38).
// 2. Lets the user choose a scripture or get one randomly.
// 3. Allows the user to return to the menu and choose another.
// 4. Adds a polished title screen for a better user experience.
// ---------------------------------------------------------


using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Title Screen
        Console.Clear();
        Console.WriteLine("=======================================");
        Console.WriteLine("   Welcome to the Scripture Memorizer ");
        Console.WriteLine("=======================================");
        Console.WriteLine("\nA helpful tool to strengthen your memory and spirit.");
        Console.WriteLine("\nPress Enter to begin...");
        Console.ReadLine();

        // List of available scriptures
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."),

            new Scripture(new Reference("Helaman", 5, 12),
                "And now, my sons, remember, remember that it is upon the rock of our Redeemer, " +
                "who is Christ, the Son of God, that ye must build your foundation; " +
                "that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, " +
                "yea, when all his hail and his mighty storm shall beat upon you, " +
                "it shall have no power over you to drag you down to the gulf of misery and endless wo, " +
                "because of the rock upon which ye are built, which is a sure foundation, " +
                "a foundation whereon if men build they cannot fall."),

            new Scripture(new Reference("Doctrine and Covenants", 1, 37, 38),
                "Search these commandments, for they are true and faithful, " +
                "and the prophecies and promises which are in them shall all be fulfilled. " +
                "What I the Lord have spoken, I have spoken, and I excuse not myself; " +
                "and though the heavens and the earth pass away, my word shall not pass away, " +
                "but shall all be fulfilled, whether by mine own voice or by the voice of my servants, it is the same.")
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine(" Scripture Memorizer");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Choose a scripture to memorize:");
            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetReferenceText()}");
            }
            Console.WriteLine("R. Random Scripture");
            Console.WriteLine("Q. Quit");
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine().Trim().ToLower();

            Scripture scripture;

            if (choice == "q")
                break;
            else if (choice == "r")
            {
                Random random = new Random();
                scripture = scriptures[random.Next(scriptures.Count)];
            }
            else if (int.TryParse(choice, out int num) && num >= 1 && num <= scriptures.Count)
                scripture = scriptures[num - 1];
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            // Begin memorization loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words, type 'menu' to choose another scripture, or 'quit' to exit.");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                    return;
                else if (input == "menu")
                    break;

                scripture.HideRandomWords(3);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden. Great job!");
                    Console.WriteLine("Press Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                }
            }
        }

        Console.WriteLine("\nThank you for using the Scripture Memorizer! ");
        Thread.Sleep(1500);
    }
}