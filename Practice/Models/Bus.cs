using System;
using System.Collections.Generic;

namespace Practice.Models;

public partial class Bus
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int SeatsCount { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
