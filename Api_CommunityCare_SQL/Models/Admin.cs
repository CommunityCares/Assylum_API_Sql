using System;
using System.Collections.Generic;

namespace Api_CommunityCare_SQL.Models;

public partial class Admin
{
    public int Id { get; set; }

    public byte IdAssylum { get; set; }

    public virtual Assylum IdAssylumNavigation { get; set; } = null!;

    public virtual Person IdNavigation { get; set; } = null!;
}
