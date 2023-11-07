using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class BasketProduct
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdBusketUser { get; set; }
    [JsonIgnore]

    public virtual BasketUser? IdBusketUserNavigation { get; set; }
 

    public virtual Product? IdProductNavigation { get; set; }
    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
