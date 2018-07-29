using System;
using System.Collections.Generic;

namespace PracticeASPNETCORE.Models
{
    public partial class Subjects
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public int? TeacherId { get; set; }

        public Teachers Teacher { get; set; }
    }
}
