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
            Console.WriteLine("Please choose a type of pet: \n1. Cat \n2. Dog \n3. Rabbit");

            Console.Write("User Input: ");
            int userInput = int.Parse(Console.ReadLine());
            string petName;
            // based on user input, display message to choose pet's name
            switch (userInput)
            {
                case 1:
                    Console.WriteLine("You've chosen a Cat. What would you like to name your pet?");
                    petName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("You've chosen a Dog. What would you like to name your pet?");
                    petName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("You've chosen a Rabbit. What would you like to name your pet?");
                    petName = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("You have selected an invalid type of pet!");
                    goto type;
            }
            Console.WriteLine("Welcome, {0}! Let's take good care of him.", petName);

            //declare and initialize values for pet's status
            int hunger = 5;
            int happiness = 5;
            int health = 8;

        //display main menu
        mainMenu:
            Console.WriteLine("Main Menu:\n1. Feed " + petName + ".\n2. Play with " + petName + ".\n3. Let " + petName + " Rest.\n4. Check " + petName + "'s Status\n5. Exit");
            //get user input from main menu
            Console.Write("User Input: ");
            int menuInput = int.Parse(Console.ReadLine());
            
            //display actions based on the user input selection from main menu
            switch (menuInput)
            {
                case 1:
                    Console.WriteLine("You fed {0}. His hunger decreases, and health improves slightly.", petName);
                    if (hunger > 0) hunger--;
                    health++;
                    goto mainMenu;
                case 2:
                    Console.WriteLine("You played with {0}. His happiness increases, and hunger increases slightly", petName);
                    hunger++;
                    happiness++;
                    goto mainMenu;
                case 3:
                    Console.WriteLine("Let {0} rest. His health improves, and happiness decreases slightly", petName);
                    health++;
                    happiness--;
                    goto mainMenu;
                case 4:
                    Console.WriteLine("{0}'s Status:\n- Hunger: {1}\n- Happiness: {2}\n -Health: {3}\n", petName, hunger, happiness, health);
                    hunger++;
                    happiness++;
                    goto mainMenu;
                case 5:
                    Console.WriteLine("Thank you for playing with {0}. Goodbye!", petName);
                    hunger++;
                    happiness++;
                    break;
                default:
                    Console.WriteLine("Please select valid option from the menu. ");
                    goto mainMenu;
            }

            //time-based change - simulate the passage of time where each action represents passage of 1 hr

            //consequences logic for neglect - too hungry, no rest, too unhappy
            //warning message bases on pet's status

        }
    }
}
