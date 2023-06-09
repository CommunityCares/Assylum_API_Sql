using System;
using System.Collections.Generic;

namespace Api_CommunityCare_SQL.Models;

public partial class Donation
{
    public int Id { get; set; }

    public string? DescriptionItems { get; set; }

    public decimal? DescriptionMonto { get; set; }

    public byte Status { get; set; }

    public DateTime RegisterDate { get; set; }

    public string? IsAnonymus { get; set; }

    public string? IsReceived { get; set; }

    public int IdCollect { get; set; }

    public string Hour { get; set; } = null!;

    public int IdCampaign { get; set; }

    public int IdDonnors { get; set; }

    //public virtual Campaign IdCampaignNavigation { get; set; } = null!;

    //public virtual Donor IdDonnorsNavigation { get; set; } = null!;
}
