using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakenplannerData.Models;

namespace TakenplannerWeb.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Chore> allChores { get; set; }
        public IEnumerable<Chore> expiredChores { get; set; }
        public IEnumerable<Chore> almostExpiredChores { get; set; }
        public IEnumerable<Chore> backlogChores { get; set; }
        public IEnumerable<Chore> todoChores { get; set; }
        public IEnumerable<Chore> doingChores { get; set; }
        public IEnumerable<Chore> doneChores { get; set; }
    }
}