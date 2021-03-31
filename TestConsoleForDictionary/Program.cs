using ChallengeThreeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleForDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Badge> _badgesDictionary = new Dictionary<int, Badge>();
            _badgesDictionary.Add(1, new Badge
            {
                BadgeID = 1,
                DoorNamesForAccess = new List<string>()
                {
                    "A1",
                    "C2",
                }
            });

            _badgesDictionary.Add(2, new Badge
            {
                BadgeID = 2,
                DoorNamesForAccess = new List<string>()
                {
                    "B1",
                    "D2",
                }
            });

            foreach (KeyValuePair<int, Badge> pair in _badgesDictionary)
            {
                    Console.WriteLine(pair.Key);
                    Console.WriteLine(pair.Value.BadgeID);
                foreach (string door in pair.Value.DoorNamesForAccess)
                {
                    if (door == "D2")
                    {
                        Console.WriteLine(pair.Key);
                        Console.WriteLine(door);
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
