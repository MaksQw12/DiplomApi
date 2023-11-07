using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<ArchiveProduct> ArchiveProducts { get; set; } = new List<ArchiveProduct>();
    [JsonIgnore]

    public virtual ICollection<BasketUser> BasketUsers { get; set; } = new List<BasketUser>();
}
