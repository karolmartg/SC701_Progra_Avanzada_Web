using Microsoft.AspNetCore.Mvc;

namespace PAW.Models;

public partial class Catalog
{
    public int Identifier { get; set; }
    public string Name { get; set; } = null!;
}