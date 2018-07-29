using System;
using System.Collections.Generic;

namespace PracticeASPNETCORE.Models
{
    public partial class HistoryStudents
    {
        public HistoryStudents()
        {
            Students = new HashSet<Students>();
        }

        public int HistoryStudentId { get; set; }
        public string LoginName { get; set; }
        public string DisplayName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Domain { get; set; }
        public string ComputerName { get; set; }
        public string SubjectName { get; set; }
        public string SubjectSection { get; set; }
        public bool HasFilledSurvey { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
