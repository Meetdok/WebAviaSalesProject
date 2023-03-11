using System;
using System.Collections.Generic;

namespace WebAviaSalesProject.Models
{
    public partial class ServicesTicket
    {
        public int ServiceTicketsId { get; set; }
        public int IdService { get; set; }
        public int ItTicket { get; set; }

        public virtual Service ServiceTickets { get; set; } = null!;
        public virtual Ticket ServiceTicketsNavigation { get; set; } = null!;
    }
}
