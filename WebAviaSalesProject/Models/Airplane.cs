using System;
using System.Collections.Generic;

namespace WebAviaSalesProject.Models
{
    public partial class Airplane
    {
        public Airplane()
        {
            Flights = new HashSet<Flight>();
        }

        public int AirplanesId { get; set; }
        public string? AirplaneTitle { get; set; }
        public int? ClassId { get; set; }
        public int? Places { get; set; }

        public virtual AirplanesClass? Class { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
