using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Room
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
