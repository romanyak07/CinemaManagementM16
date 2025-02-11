using System;
using System.Collections.Generic;

namespace CinemaManagementM16.Models;

public partial class Director
{
    public int DirectorId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Nationality { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
