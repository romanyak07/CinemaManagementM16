using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Advertisement
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Duration { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
