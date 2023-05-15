using System;
using System.Collections.Generic;

namespace Information_Flight.Models;

public partial class Chitietchuyenbay
{
    public int Mact { get; set; }

    public int? Macb { get; set; }

    public int? Masb { get; set; }

    public int? Thoigiandung { get; set; }

    public string? Moto { get; set; }

    public virtual Chuyenbay? MacbNavigation { get; set; }

    public virtual Sanbay? MasbNavigation { get; set; }
}
