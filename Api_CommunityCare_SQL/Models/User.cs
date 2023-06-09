using System;
using System.Collections.Generic;

namespace Api_CommunityCare_SQL.Models;

public partial class User
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Email { get; set; } = null!;

    //public virtual Person IdNavigation { get; set; } = null!;
}
