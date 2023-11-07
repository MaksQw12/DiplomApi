using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class CategoryProduct
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;
    [JsonIgnore]

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
