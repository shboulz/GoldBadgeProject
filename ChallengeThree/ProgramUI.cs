using ChallengeThreeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree
{
    class ProgramUI
    {
        
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        
        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Press any key to exit menu. Thank you!");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddABadge()
        {
            Console.Clear();
            Badge badgeContent = new Badge();
            Console.WriteLine("Follow instructions for each prompt thank you!");

            Console.WriteLine("Enter a new badge ID must be FIVE DIGITS");
            badgeContent.BadgeID = int.Parse(Console.ReadLine());


            bool listDoorAccessForNewBadge = false;
            List<string> ListOfDoors = new List<string>();
            while (!listDoorAccessForNewBadge)
            {
                Console.WriteLine("Do you want to list Door Access to the new Badge? (yes/no)");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "yes")
                {
                    Console.WriteLine("Type from the following door codes below\n" +
                        "............................................................\n" +
                        "(A1, A2, A3, A4, A5, A6, A7)-(B1, B2, B3, B4, B5, B6, B7)");
                    string userTypedDoorAccess = Console.ReadLine().ToUpper();

                    ListOfDoors.Add(userTypedDoorAccess);
                }
                else
                {
                    listDoorAccessForNewBadge = true;
                }
            }
            badgeContent.DoorNamesForAccess.AddRange(ListOfDoors);

            bool isSuccessful = _badgeRepo.AddNewBadge(badgeContent);
            if (isSuccessful)
            {
                Console.WriteLine("New badge has been created");
            }
            else
            {
                Console.WriteLine("Failed to create new badge!");
            }

            Console.ReadKey();
            Console.Clear();
            
        }

        private void EditABadge()
        {
            Console.Clear();
            
            Console.WriteLine("What is the badge number to update? ");
            int userInput = int.Parse(Console.ReadLine());
            Badge badgeWithUpdatedInfo = new Badge();

            bool addNewDoorAccess = false;
            List<string> ListOfDoors = new List<string>();
            while (!addNewDoorAccess)
            {
                Console.WriteLine("Do you want to Add new door access? (yes/no)");
                string userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "yes")
                {
                    Console.WriteLine("Type from the following door codes below\n" +
                        "............................................................\n" +
                        "(A1, A2, A3, A4, A5, A6, A7)-(B1, B2, B3, B4, B5, B6, B7)");
                    string userInputDoorAccess = Console.ReadLine().ToUpper();
                    ListOfDoors.Add(userInputDoorAccess);

                }
                else
                {
                    addNewDoorAccess = true;
                }
            }
            badgeWithUpdatedInfo.DoorNamesForAccess.AddRange(ListOfDoors);

            bool isSuccessful = _badgeRepo.UpdateBadgeByKey(userInput, badgeWithUpdatedInfo);
            if (isSuccessful)
            {
                Console.WriteLine("Successful");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            Console.ReadKey();

        }

        private void ListAllBadges()
        {
            Console.Clear();
            foreach (KeyValuePair<int, Badge> badgeContent in _badgeRepo.ShowAllBadges())
            {
                ShowBadgeDetails(badgeContent);
            }
            Console.ReadKey();
        }

        private void ShowBadgeDetails(KeyValuePair<int, Badge> badgeContent)
        {
            Console.WriteLine($"Key: {badgeContent.Key}\n" +
                $"Badge #: {badgeContent.Value.BadgeID}");
            foreach (string doorAccess in badgeContent.Value.DoorNamesForAccess)
            {
                Console.WriteLine(doorAccess);
            }
            Console.WriteLine("....................................");
        }

        private void Seed()
        {

            _badgeRepo.AddNewBadge( new Badge
            {
                BadgeID = 12345,
                DoorNamesForAccess = new List<string>()
                {
                    "A7",
                }
            });

            _badgeRepo.AddNewBadge( new Badge
            {
                BadgeID = 22345,
                DoorNamesForAccess = new List<string>()
                {
                    "A1", "A4", "B1", "B2",
                }
            });

            _badgeRepo.AddNewBadge(new Badge
            {
                BadgeID = 32345,
                DoorNamesForAccess = new List<string>()
                {
                    "A4", "A5",
                }
            });
        }
    }
}
