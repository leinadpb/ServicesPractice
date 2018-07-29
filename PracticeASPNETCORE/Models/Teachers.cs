using System;
using System.Collections.Generic;

namespace PracticeASPNETCORE.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            Admins = new HashSet<Admins>();
            Claims = new HashSet<Claims>();
            Complains = new HashSet<Complains>();
            Students = new HashSet<Students>();
            Subjects = new HashSet<Subjects>();
            Suggestion = new HashSet<Suggestion>();
        }

        public int TeacherId { get; set; }
        public string LoginName { get; set; }
        public string DisplayName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Domain { get; set; }
        public string ComputerName { get; set; }
        public bool HasFilledSurvey { get; set; }
        public int? HistoryTeacherId { get; set; }

        public HistoryTeachers HistoryTeacher { get; set; }
        public ICollection<Admins> Admins { get; set; }
        public ICollection<Claims> Claims { get; set; }
        public ICollection<Complains> Complains { get; set; }
        public ICollection<Students> Students { get; set; }
        public ICollection<Subjects> Subjects { get; set; }
        public ICollection<Suggestion> Suggestion { get; set; }
    }
}
