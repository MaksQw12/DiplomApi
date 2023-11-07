using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DiplomBackend.Models;

public partial class ArchiveProduct
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdOrder { get; set; }
    [JsonIgnore]

    public virtual Order? IdOrderNavigation { get; set; }
    [JsonIgnore]

    public virtual User? IdUserNavigation { get; set; }
}
