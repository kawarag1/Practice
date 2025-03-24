using System;
using System.Collections.Generic;

namespace Practice.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int TripId { get; set; }

    public int PassengerId { get; set; }

    public int Cost { get; set; }

    public bool Baggage { get; set; }

    public string SeatNumber { get; set; } = null!;

    public virtual Passenger Passenger { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
