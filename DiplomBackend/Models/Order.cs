using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdBusketProduct { get; set; }

    public DateTime Date { get; set; }

    public int Count { get; set; }
    [JsonIgnore]

    public virtual ICollection<ArchiveProduct> ArchiveProducts { get; set; } = new List<ArchiveProduct>();

    public virtual BasketProduct? IdBusketProductNavigation { get; set; }
}
