using System;
using System.Collections.Generic;

namespace Practice.Models;

public partial class Driver
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public long PassportId { get; set; }

    public long LicenceId { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
