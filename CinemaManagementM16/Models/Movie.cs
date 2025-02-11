using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime? Duration { get; set; }

    public int? ResumeId { get; set; }

    public int? DirectorId { get; set; }

    public string? State { get; set; }

    public byte[]? MovieImage { get; set; }

    public virtual Director? Director { get; set; }

    public virtual Resume? Resume { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
}
