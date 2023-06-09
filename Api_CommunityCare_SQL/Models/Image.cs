using System;
using System.Collections.Generic;

namespace Api_CommunityCare_SQL.Models;

public partial class Image
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int? IdCampaign { get; set; }

    public virtual Campaign? IdCampaignNavigation { get; set; }
}
