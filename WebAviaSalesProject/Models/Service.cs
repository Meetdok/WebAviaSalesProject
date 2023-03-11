using System;
using System.Collections.Generic;

namespace WebAviaSalesProject.Models
{
    public partial class Service
    {
        public Service()
        {
            FlightCompanies = new HashSet<FlightCompany>();
        }

        public int ServiceId { get; set; }
        public string? ServiceType { get; set; }
        public decimal? ServiceCost { get; set; }

        public virtual ServicesTicket? ServicesTicket { get; set; }
        public virtual ICollection<FlightCompany> FlightCompanies { get; set; }
    }
}
