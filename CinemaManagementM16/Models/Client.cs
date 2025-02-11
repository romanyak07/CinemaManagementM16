using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Client
{
    public string Name { get; set; } = null!;

    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
