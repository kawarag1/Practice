using System;
using System.Collections.Generic;

namespace Practice.Models;

public partial class Trip
{
    public int Id { get; set; }

    public int BusId { get; set; }

    public int DriverId { get; set; }

    public int StatusId { get; set; }

    public int Route { get; set; }

    public DateTime DatetimeStart { get; set; }

    public DateTime DatetimeEnd { get; set; }

    public virtual Bus Bus { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Route RouteNavigation { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
