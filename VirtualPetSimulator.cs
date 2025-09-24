using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class VirtualPetSimulator
    {
        static void Main(string[] args)
        {
        //let user input and choose the type of pet
        type:
            Console.WriteLine("Welcome to Virtual Pet Simulator. You can choose a pet type, give it a name and interact or play with it. Let's get started!");
            Console.WriteLine();
            Console.WriteLine("Please choose a type of pet: \n1. Cat \n2. Dog \n3. Rabbit");
            Console.WriteLine();

            Console.Write("User Input: ");
            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine();
            string petName;
            // based on user input, display message to choose pet's name
            switch (userInput)
            {
                case 1:
                    Console.Write("You've chosen a Cat. What would you like to name your pet? ");
                    petName = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("You've chosen a Dog. What would you like to name your pet? ");
                    petName = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("You've chosen a Rabbit. What would you like to name your pet? ");
                    petName = Console.ReadLine();
                    break;
                default:
                    Console.Write("You have selected an invalid type of pet! ");
                    goto type;
            }
            Console.WriteLine();
            Console.WriteLine("Welcome, {0}! Let's take good care of him.", petName);

            //declare and initialize values for pet's status
            // Hunger scale explanation:
            // 0 = starving, 10 = very full
            // Feeding increases hunger (fullness), time/playing decreases hunger
            int hunger = 5;//low hunger level (0) means dog is very hungry and 10 means dog is not hungry and is full
            int happiness = 5;//low happiness level (0) means dog is sad, and 10 means dog is at his happiest
            int health = 8;//low health level (0) means dog has no energy, and 10 means dog is full of energy
            int countInteraction = 0;

            bool running = true;
            while (running)
            {
                //consequences logic for neglect - too hungry, no rest, too unhappy
                //warning message bases on pet's status
                Console.WriteLine();
                if (hunger <= 2) Console.WriteLine("WARNING! {0} is feeling extremely hungry. Be sure to feed him.", petName);
                if (happiness <= 2) Console.WriteLine("WARNING! {0} is feeling sad. Be sure to play with him.", petName);
                if (health <= 2) Console.WriteLine("WARNING! {0} is unwell. Be sure to feed him and make him rest.", petName);
                if (hunger >= 9) Console.WriteLine("NOTICE: {0} is very full. Maybe skip feeding for now.", petName);
                if (happiness >= 9) Console.WriteLine("NOTICE: {0} is extremely happy and energetic!", petName);
                if (health >= 9) Console.WriteLine("NOTICE: {0} is in excellent health!", petName);
                if (hunger <= 1 || happiness <= 1)
                {
                    if (health > 0) health--;
                    Console.WriteLine($"{petName} is suffering from neglect! Health is dropping.");
                }
                Console.WriteLine();

                //time-based change - simulate the passage of time where each action represents passage of 1 hr
                //decrement each status by 1 after every 3 interaction which counts as 3 hrs
                if (countInteraction % 3 == 0 && countInteraction >= 3)
                {
                    Console.WriteLine("Your pet has been active for 3 hours. Hunger decreases (pet is hungrier), health and happiness decrease slightly.");
                    if (hunger > 0) hunger--;
                    if (health > 0) health--;
                    if (happiness > 0) happiness--;
                }

                //display main menu
                Console.WriteLine("Main Menu:\n1. Feed " + petName + ".\n2. Play with " + petName + ".\n3. Let " + petName + " Rest.\n4. Check " + petName + "'s Status\n5. Exit");
                Console.WriteLine();

                //get user input from main menu
                Console.Write("User Input: ");
                int menuInput = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //display actions and status based on the user input selection from main menu
                switch (menuInput)
                {
                    case 1:
                        Console.WriteLine("You fed {0}. His hunger decreases, and health improves slightly.", petName);
                        if (hunger < 10) hunger++;
                        if (health < 10) health++;
                        countInteraction++;//feeding counts as 1 interaction
                        break;
                    case 2:
                        if (hunger <= 1)
                        {
                            Console.WriteLine($"{petName} is too hungry to play! Feed them first.");
                        }
                        else
                        {
                            Console.WriteLine($"You played with {petName}. Happiness increases but hunger rises.");
                            if (happiness < 10) happiness++;
                            if (hunger > 0) hunger--;
                        }
                        countInteraction++;//playing counts as 1 interaction
                        break;
                    case 3:
                        Console.WriteLine("Let {0} rest. His health improves, and happiness decreases slightly", petName);
                        if (health < 10) health++;
                        if (happiness > 0) happiness--;
                        countInteraction++;//Resting counts as 1 interaction
                        break;
                    case 4:
                        Console.WriteLine("{0}'s Status:\n- Hunger: {1}\n- Happiness: {2}\n -Health: {3}\n", petName, hunger, happiness, health);
                        break;
                    case 5:
                        Console.WriteLine("Thank you for playing with {0}. Goodbye!", petName);
                        running = false; // exit loop
                        break;
                    default:
                        Console.WriteLine("Please select valid option from the menu. ");
                        break;
                }
            }
        }
    }
}
