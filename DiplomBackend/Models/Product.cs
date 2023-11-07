using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Count { get; set; }

    public string Article { get; set; } = null!;

    public int IdCategory { get; set; }

    public int IdSupplier { get; set; }
    [JsonIgnore]

    public virtual ICollection<Barcode> Barcodes { get; set; } = new List<Barcode>();
    [JsonIgnore]

    public virtual ICollection<BasketProduct> BasketProducts { get; set; } = new List<BasketProduct>();
    [JsonIgnore]

    public virtual CategoryProduct? IdCategoryNavigation { get; set; }
    [JsonIgnore]

    public virtual Supplier? IdSupplierNavigation { get; set; }


    public virtual ProductPhoto? ProductPhoto { get; set; }
}
