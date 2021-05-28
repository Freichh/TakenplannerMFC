using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakenplannerWeb.Models
{
    public class IndexViewModel
    {
        public IEnumerable<TakenplannerData.Models.Chore> backlogchores { get; set; }
        public IEnumerable<TakenplannerData.Models.Chore> todochores { get; set; }
        public IEnumerable<TakenplannerData.Models.Chore> doingchores { get; set; }
        public IEnumerable<TakenplannerData.Models.Chore> donechores { get; set; }
    }
}