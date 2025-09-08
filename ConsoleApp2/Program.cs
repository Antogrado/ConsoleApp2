using System;

class EscapeRoom
{
    static string playerName;
    static bool hasArtifact1 = false;
    static bool hasArtifact2 = false;
    static bool hasArtifact3 = false;
    static bool statueActivated = false;
    static bool hasKey = false;
    static bool boxOpened = false;
    static bool hasPicklock = false;
    static int ventilationAttempts = 0;

    static void Main()
    {
        Console.WriteLine("You wake up in a strange room and try to remember your name..");
        Console.Write("Enter the character name: ");
        playerName = Console.ReadLine();

        Console.WriteLine($"\nHello, {playerName}! Welcome.\n");

        
        while (true)
        {
            ShowOptions();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TryOpenDoor();
                    break;
                case "2":
                    LookUnderBed();
                    break;
                case "3":
                    OpenBox();
                    break;
                case "4":
                    OpenVentilation();
                    break;
                case "5":
                    LookAtNightstand();
                    break;
                case "6":
                    LookAtStatue();
                    break;
                default:
                    Console.WriteLine(" Select an action 1 - 6.");
                    break;
            }
            if (HasEscaped())
                break;
        }
    }

    static void ShowOptions()
    {
        Console.WriteLine("\nWhat do you want to do?");
        Console.WriteLine("1. Open the door");
        Console.WriteLine("2. Look under the bed");
        Console.WriteLine("3. Open the drawer in the corner of the room");
        Console.WriteLine("4. Open the vent");
        Console.WriteLine("5. Take a look at the nightstand");
        Console.WriteLine("6. Look at the statue next to the door");
        Console.Write("Select an action (1-6): ");
    }

    static void TryOpenDoor()
    {
        if (!hasPicklock)
        {
            Console.WriteLine("The door is locked. You need to find a master key to open the door.");
            return;
        }

        Console.WriteLine("You use the master key and open the door...");
        Console.WriteLine($"Congratulations, {playerName}! You have successfully escaped from the room.!");
    }

    static void LookUnderBed()
    {
        if (!hasArtifact1)
        {
            hasArtifact1 = true;
            Console.WriteLine($"{playerName}, You found the first artifact under the bed.");
        }
        else
        {
            Console.WriteLine("There's nothing under the bed.");
        }
    }

    static void OpenBox()
    {
        if (!hasKey)
        {
            Console.WriteLine("The box is locked. You need to find the key.");
            return;
        }

        if (!boxOpened)
        {
            boxOpened = true;
            hasPicklock = true;
            Console.WriteLine($"{playerName}, You opened the box and found the master key to the door.");
        }
        else
        {
            Console.WriteLine("The box is already open, empty inside.");
        }
    }

    static void OpenVentilation()
    {
        if (!hasArtifact2)
        {
            ventilationAttempts++;
            if (ventilationAttempts < 3)
            {
                Console.WriteLine("The ventilation is tightly closed. Try again.");
            }
            else
            {
                hasArtifact2 = true;
                Console.WriteLine($"{playerName}, You opened the ventilation and found the second artifact.");
            }
        }
        else
        {
            Console.WriteLine("The ventilation is open, but there is nothing else.");
        }
    }

    static void LookAtNightstand()
    {
        if (!hasArtifact3)
        {
            hasArtifact3 = true;
            Console.WriteLine($"{playerName}, You found the third artifact on the nightstand.");
        }
        else
        {
            Console.WriteLine("There is nothing new on the nightstand.");
        }
    }

    static void LookAtStatue()
    {
        if (statueActivated)
        {
            Console.WriteLine("The statue has already been activated and has given you the key to the box.");
            return;
        }

        if (hasArtifact1 && hasArtifact2 && hasArtifact3)
        {
            statueActivated = true;
            hasKey = true;
            Console.WriteLine($"{playerName}, By activating the statue with three artifacts, you received the key to the box.");
        }
        else
        {
            Console.WriteLine("The statue looks mysterious. It seems to require three artifacts to activate it.");
        }
    }

    static bool HasEscaped()
    {
        return hasPicklock && Console.ReadLine().Trim() == "1" && hasPicklock;
    }
}