using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Resume
{
    public int ResumeId { get; set; }

    public string? Name { get; set; }

    public DateTime? Duration { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
