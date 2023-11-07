using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class BasketUser
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    [JsonIgnore]
    public virtual ICollection<BasketProduct> BasketProducts { get; set; } = new List<BasketProduct>();
    [JsonIgnore]

    public virtual User? IdUserNavigation { get; set; }
}
