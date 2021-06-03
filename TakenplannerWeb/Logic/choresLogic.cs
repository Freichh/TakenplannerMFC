using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakenplannerData.Models;

namespace TakenplannerWeb.Logic
{
    public class choresLogic
    {
        public static void CheckExpiredChores(IEnumerable<Chore> chores)
        {
            foreach (var chore in chores)
            {
                if (chore.StartDate < DateTime.Now)
                {
                    chore.Expired = true;
                }
                if (chore.StartDate >= DateTime.Now)
                {
                    chore.Expired = false;
                }
            }
        }        
        
        public static void CheckAlmostExpiredChores(IEnumerable<Chore> chores)
        {
            foreach (var chore in chores)
            {
                TimeSpan remainingTime = chore.EndDate - DateTime.Now;
                if (remainingTime.Days <= 3 && remainingTime.Days > 0)
                {
                    chore.AlmostExpired = true;
                }
                if (remainingTime.Days > 3)
                {
                    chore.AlmostExpired = false;
                }
            }
        }
    }
}