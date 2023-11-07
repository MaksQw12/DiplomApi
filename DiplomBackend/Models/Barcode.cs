using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class Barcode
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int IdProduct { get; set; }
    [JsonIgnore]
    public virtual Product? IdProductNavigation { get; set; }
}
