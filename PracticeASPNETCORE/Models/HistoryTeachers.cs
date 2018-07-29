using System;
using System.Collections.Generic;

namespace PracticeASPNETCORE.Models
{
    public partial class HistoryTeachers
    {
        public HistoryTeachers()
        {
            Teachers = new HashSet<Teachers>();
        }

        public int HistoryTeacherId { get; set; }
        public string LoginName { get; set; }
        public string DisplayName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Domain { get; set; }
        public string ComputerName { get; set; }
        public bool HasFilledSurvey { get; set; }

        public ICollection<Teachers> Teachers { get; set; }
    }
}
