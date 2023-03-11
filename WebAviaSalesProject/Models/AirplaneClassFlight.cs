using System;
using System.Collections.Generic;

namespace WebAviaSalesProject.Models
{
    public partial class AirplaneClassFlight
    {
        public int Idflight { get; set; }
        public int? ClassId { get; set; }
        public long? SeatCost { get; set; }

        public virtual AirplanesClass IdflightNavigation { get; set; } = null!;
        public virtual Flight? Flight { get; set; }
    }
}
