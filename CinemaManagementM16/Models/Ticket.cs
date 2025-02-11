using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int SessionId { get; set; }

    public int? ChairPlace { get; set; }

    public string? Type { get; set; }

    public decimal? Price { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();

    public virtual Session Session { get; set; } = null!;
}
