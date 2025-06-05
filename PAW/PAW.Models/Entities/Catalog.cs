using PAW.Models.PAWModels;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PAW.Models.Entities;

public partial class Catalog : Entity
{
    [JsonPropertyName("identifier")]
    public int Identifier { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("modified")]
    public DateTime Modified { get; set; }

}
