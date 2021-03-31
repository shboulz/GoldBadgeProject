using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepository
{
    public class ClaimRepo
    {
        
        protected readonly Queue<Claim> _claimDirectory = new Queue<Claim>();

        public bool AddClaimToQueue(Claim claimContent)
        {
            _claimDirectory.Enqueue(claimContent);
            return true;
        }

        public Queue<Claim> GetClaimsInQueue()
        {
            return _claimDirectory;
        }
        public Claim NextClaimInQueue()
        {
            return _claimDirectory.Peek();
        }

        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim claimContent in _claimDirectory)
            {
                if (claimContent.ClaimID == claimID)
                {
                    return claimContent;
                }
            }
            return null;
        }

       public bool PullClaim()
        {
            Claim claimContent = NextClaimInQueue();
            if (claimContent == null)
            {
                return false;
            }
            else
            {
                _claimDirectory.Dequeue();
                return true;
            }
        }
    }
}
