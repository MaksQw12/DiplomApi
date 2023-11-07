using Newtonsoft.Json;
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
    [JsonIgnore]

    public virtual BasketProduct? IdBusketProductNavigation { get; set; } 
}
