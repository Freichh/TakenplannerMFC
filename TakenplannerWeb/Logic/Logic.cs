using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakenplannerData.Models;

namespace TakenplannerWeb.Logic
{
    public class Logic
    {
        //TODO Logic implementeren
        // background color red / green. Boolean gebruiken
        public static void CheckExpiredChores(List<Chore> chores)
        {
            //DateTime currentTime = DateTime.Now;
            foreach (var chore in chores)
            {
                if (chore.StartDate < DateTime.Now)
                {
                    // Boolean aanpassen.
                }
            }
        }
    }
}