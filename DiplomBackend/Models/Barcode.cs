using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class Barcode
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int IdProduct { get; set; }


    public virtual Product? IdProductNavigation { get; set; }
}
