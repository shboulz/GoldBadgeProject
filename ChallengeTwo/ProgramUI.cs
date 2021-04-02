using ChallengeTwoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
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
                Console.WriteLine("Welcome To Komodo Claims Menu Select One Of The Options Below To Get Started\n" +
                    "1. See All Claims\n" +
                    "2. Take Care Of Next Claim\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit Application");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Thank you........");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claim claimContent = new Claim();
            Console.WriteLine("Follow The Promts To Create A New Claim Thank You");

            Console.WriteLine("Enter The Claim ID.");
            claimContent.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter The Claim Type. (Select A Number From 1-3)\n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    claimContent.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claimContent.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claimContent.ClaimType = ClaimType.Theft;
                    break;
                
            }

            Console.WriteLine("Enter A Claim Description.");
            claimContent.Description = Console.ReadLine();

            Console.WriteLine("Ammount of Damage. (Enter Amount Without $ Symbol)");
            claimContent.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Date Of Accident (Enter in the Following Format Year, Month, Day)");
            claimContent.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Date Of Claim (Enter in the Following Format: Year, Month, Day)");
            claimContent.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"This Claim {claimContent.IsValidWithinTimeFrame}");

            bool isSuccessful = _claimRepo.AddClaimToQueue(claimContent);
            if (isSuccessful)
            {
                Console.WriteLine("New Claim Has Been Created");
            }
            else
            {
                Console.WriteLine("New Claim Failed!");
            }

            Console.ReadKey();
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            ShowClaimData();
            
            Console.ReadKey();
        }

        private void ShowClaimData()
        {
            Queue<Claim> claims = _claimRepo.GetClaimsInQueue();
            foreach (Claim claimContent in claims)
            {
                ShowClaimDetails(claimContent);
                Console.WriteLine("........................................................................................................................");
            }
        }

        private void ShowClaimDetails (Claim claimContent)
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,27} {6,28}\n", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,20} {5,30} {6,18:N1}", Convert.ToString(claimContent.ClaimID), Convert.ToString(claimContent.ClaimType), Convert.ToString(claimContent.Description), Convert.ToString(claimContent.ClaimAmount), Convert.ToString(claimContent.DateOfIncident), Convert.ToString(claimContent.DateOfClaim), Convert.ToString(claimContent.IsValidWithinTimeFrame));

            //Commented this out to implement a different format this is the best i could do this time at night. however picked up StringBuilder knowledge. will improve on this 
            // if you want the old style menu just uncomment below and comment the lines above. it should look better however tried to get it to look like the example.
            /*Console.WriteLine($"ClaimID: {claimContent.ClaimID}\n" +
                $"Type: {claimContent.ClaimType}\n" +
                $"Description: {claimContent.Description}\n" +
                $"Amount: {claimContent.ClaimAmount}\n" +
                $"DateOfAccident: {claimContent.DateOfIncident}\n" +
                $"DateOfClaim: {claimContent.DateOfClaim}\n" +
                $"IsValid: {claimContent.IsValidWithinTimeFrame}");*/

        }


        private void TakeCareOfNextClaim()
        {
            Console.Clear();

            Claim claimContent = _claimRepo.NextClaimInQueue();

            Console.WriteLine($"ClaimID: {claimContent.ClaimID}\n" +
                $"Type: {claimContent.ClaimType}\n" +
                $"Description: {claimContent.Description}\n" +
                $"Amount: {claimContent.ClaimAmount}\n" +
                $"DateOfAccident: {claimContent.DateOfIncident}\n" +
                $"DateOfClaim: {claimContent.DateOfClaim}\n" +
                $"IsValid: {claimContent.IsValidWithinTimeFrame}");

            Console.WriteLine("Do You Want To Deal With This Claim Now? (yes/no)");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "yes")
            {
                bool isSuccessful = _claimRepo.PullClaim();
                if (isSuccessful)
                {
                    Console.WriteLine("Claim Has Been Pulled Out Of Queue ");
                }
            }
            else if(userInput == "no")
            {
                Console.WriteLine("Going Back To Main Menu");
            }

            Console.ReadKey();
        }

        private void Seed()
        {
            Claim claimContentA = new Claim(1, ClaimType.Car, "Tester Test", 2000, DateTime.Parse("2020, 01, 30"), DateTime.Parse("2020, 02, 27"));
            Claim claimContentB = new Claim(23, ClaimType.Home, "Tester Test", 233000, DateTime.Parse("2020, 03, 30"), DateTime.Parse("2020, 05, 27"));
            Claim claimContentC = new Claim(12, ClaimType.Car, "Tester Test", 1400, DateTime.Parse("2020, 05, 30"), DateTime.Parse("2020, 06, 15"));
            Claim claimContentD = new Claim(10, ClaimType.Theft, "Tester Test", 2500, DateTime.Parse("2020, 01, 30"), DateTime.Parse("2020, 03, 23"));

            _claimRepo.AddClaimToQueue(claimContentA);
            _claimRepo.AddClaimToQueue(claimContentB);
            _claimRepo.AddClaimToQueue(claimContentC);
            _claimRepo.AddClaimToQueue(claimContentD);

        }
    }
}
