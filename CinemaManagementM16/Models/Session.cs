using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Session
{
    public int Id { get; set; }

    public int? RoomId { get; set; }

    public int? MovieId { get; set; }

    public TimeOnly? StartTime { get; set; }

    public DateOnly? Date { get; set; }

    public DateTime? Duration { get; set; }

    public bool? State { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual Room? Room { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Advertisement> Ads { get; set; } = new List<Advertisement>();
}
