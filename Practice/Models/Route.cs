using System;
using System.Collections.Generic;

namespace Practice.Models;

public partial class Route
{
    public int Id { get; set; }

    public string StartCity { get; set; } = null!;

    public string EndCity { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
