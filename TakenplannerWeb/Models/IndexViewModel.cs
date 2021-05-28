using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakenplannerWeb.Models
{
    public class IndexViewModel
    {
        public IEnumerable<TakenplannerData.Models.Chore> backlogChores { get; set; }
        public IEnumerable<TakenplannerData.Models.Chore> todoChores { get; set; }
        public IEnumerable<TakenplannerData.Models.Chore> doingChores { get; set; }
        public IEnumerable<TakenplannerData.Models.Chore> doneChores { get; set; }
    }
}