using System;
using System.Collections.Generic;

namespace PracticeASPNETCORE.Models
{
    public partial class Complains
    {
        public int ComplainId { get; set; }
        public string ComplainText { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }

        public Students Student { get; set; }
        public Teachers Teacher { get; set; }
    }
}
