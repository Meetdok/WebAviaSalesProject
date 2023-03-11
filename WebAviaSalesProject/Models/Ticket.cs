using System;
using System.Collections.Generic;

namespace WebAviaSalesProject.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string? TicketTitle { get; set; }
        public decimal? TicketCost { get; set; }
        public DateTime? TicketDate { get; set; }
        public int? UserId { get; set; }
        public string? TicketStatus { get; set; }
        public long? Seats { get; set; }

        public virtual User? User { get; set; }
        public virtual ServicesTicket? ServicesTicket { get; set; }
    }
}
