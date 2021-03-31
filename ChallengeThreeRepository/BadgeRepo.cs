using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepository
{
    public class BadgeRepo
    {

        protected Dictionary<int, Badge> _badgesDictionary = new Dictionary<int, Badge>();
        int _Count = 0;


        public Dictionary<int, Badge> ShowAllBadges()
        {
            return _badgesDictionary;
        }

        public bool AddNewBadge(Badge badgeContent)
        {
            _Count++;
            _badgesDictionary.Add(_Count, badgeContent);
            return true;
        }

        public Badge GetBadgeByKey(int key)
        {
            foreach (var badgeContent in _badgesDictionary)
            {
                if (badgeContent.Key == key)
                {
                    return badgeContent.Value;
                }
            }
            return null;
        }


        public bool UpdateBadgeByKey(int originalBadgeKey, Badge newBadgeContent)
        {
            Badge oldBadgeContent = GetBadgeByKey(originalBadgeKey);
            if (oldBadgeContent == null)
            {
                return false;
            }
            else
            {
                oldBadgeContent.DoorNamesForAccess = newBadgeContent.DoorNamesForAccess;
                return true;
            }
        }
    }
}
