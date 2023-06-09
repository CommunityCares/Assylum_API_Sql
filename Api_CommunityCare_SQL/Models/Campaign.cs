using System;
using System.Collections.Generic;

namespace Api_CommunityCare_SQL.Models;

public partial class Campaign
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Requirement { get; set; } = null!;

    public DateTime InitialDate { get; set; }

    public DateTime CloseDate { get; set; }

    public byte Status { get; set; }

    public DateTime RegisterDate { get; set; }

    public byte IdAssylum { get; set; }

    //public virtual ICollection<Collect> Collects { get; set; } = new List<Collect>();

    //public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    //public virtual Assylum IdAssylumNavigation { get; set; } = null!;

    //public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}
