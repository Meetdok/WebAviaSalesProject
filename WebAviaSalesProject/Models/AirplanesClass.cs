using System;
using System.Collections.Generic;

namespace WebAviaSalesProject.Models
{
    public partial class AirplanesClass
    {
        public AirplanesClass()
        {
            Airplanes = new HashSet<Airplane>();
        }

        public int AirplaneClassId { get; set; }
        public string? ClassName { get; set; }

        public virtual AirplaneClassFlight? AirplaneClassFlight { get; set; }
        public virtual ICollection<Airplane> Airplanes { get; set; }
    }
}
