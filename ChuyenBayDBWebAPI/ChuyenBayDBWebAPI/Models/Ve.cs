using System;
using System.Collections.Generic;

namespace ChuyenBayDBWebAPI.Models;

public partial class Ve
{
    public int Mave { get; set; }

    public string? Hotenhanhkhach { get; set; }

    public string? Cmnd { get; set; }

    public int? Macb { get; set; }

    public int? Loaighe { get; set; }

    public decimal? Giaghe { get; set; }

    public virtual ChuyenBay? MacbNavigation { get; set; }
}
