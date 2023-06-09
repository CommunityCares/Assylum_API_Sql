using System;
using System.Collections.Generic;

namespace Api_CommunityCare_SQL.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? SecondLastName { get; set; }

    public byte Status { get; set; }

    public DateTime RegisterDate { get; set; }

    public string Ci { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    //public virtual Admin? Admin { get; set; }

    //public virtual Donor? Donor { get; set; }

    //public virtual User? User { get; set; }
}
