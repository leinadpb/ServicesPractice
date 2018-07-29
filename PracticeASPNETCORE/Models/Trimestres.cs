using System;
using System.Collections.Generic;

namespace PracticeASPNETCORE.Models
{
    public partial class Trimestres
    {
        public int TrimestreId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Active { get; set; }
    }
}
