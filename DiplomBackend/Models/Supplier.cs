using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string SupplaierName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;
    [JsonIgnore]

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
