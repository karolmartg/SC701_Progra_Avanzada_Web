using PAW.Models.PAWModels;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PAW.Models;

public partial class Catalog
{
    [JsonPropertyName("identifier")]
    public int Identifier { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }
    
    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }
    
    [JsonPropertyName("rating")]
    public int? Rating { get; set; }


    
    [JsonPropertyName("modified")]
    public DateTime Modified { get; set; }
    

}
