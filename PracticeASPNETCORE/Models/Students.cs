using System;
using System.Collections.Generic;

namespace PracticeASPNETCORE.Models
{
    public partial class Students
    {
        public Students()
        {
            Claims = new HashSet<Claims>();
            Complains = new HashSet<Complains>();
            Suggestion = new HashSet<Suggestion>();
        }

        public int StudentId { get; set; }
        public string DisplayName { get; set; }
        public string LoginName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Domain { get; set; }
        public string ComputerName { get; set; }
        public string SubjectName { get; set; }
        public string SubjectSection { get; set; }
        public string SubjectCode { get; set; }
        public bool HasFilledSurvey { get; set; }
        public int? HistoryStudentId { get; set; }
        public int? TeacherId { get; set; }

        public HistoryStudents HistoryStudent { get; set; }
        public Teachers Teacher { get; set; }
        public ICollection<Claims> Claims { get; set; }
        public ICollection<Complains> Complains { get; set; }
        public ICollection<Suggestion> Suggestion { get; set; }
    }
}
