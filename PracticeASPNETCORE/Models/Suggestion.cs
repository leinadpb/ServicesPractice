using System;
using System.Collections.Generic;

namespace PracticeASPNETCORE.Models
{
    public partial class Suggestion
    {
        public int SuggestionId { get; set; }
        public string SuggestionText { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }

        public Students Student { get; set; }
        public Teachers Teacher { get; set; }
    }
}
