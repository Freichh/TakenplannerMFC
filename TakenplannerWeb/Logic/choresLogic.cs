using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakenplannerData.Models;

namespace TakenplannerWeb.Logic
{
    public class choresLogic
    {
        //TODO Logic implementeren
        // background color red / green. Boolean gebruiken
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
    }
}