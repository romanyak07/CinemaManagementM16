using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Sell
{
    public int SellId { get; set; }

    public int? TicketId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
