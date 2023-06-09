using System;
using System.Collections.Generic;

namespace Api_CommunityCare_SQL.Models;

public partial class Collect
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int IdCampaign { get; set; }

    //public virtual Campaign IdCampaignNavigation { get; set; } = null!;
}
