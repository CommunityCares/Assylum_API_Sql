using System;
using System.Collections.Generic;

namespace Api_CommunityCare_SQL.Models;

public partial class Donor
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public string Region { get; set; } = null!;

    //public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    //public virtual Person IdNavigation { get; set; } = null!;
}
