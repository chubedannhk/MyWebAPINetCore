using System;
using System.Collections.Generic;

namespace Information_Flight.Models;

public partial class Ve
{
    public int Mave { get; set; }

    public int? Mahk { get; set; }

    public int? Macb { get; set; }

    public int? Soghe { get; set; }

    public int? Loaighe { get; set; }

    public decimal? Giaghe { get; set; }

    public virtual Chuyenbay? MacbNavigation { get; set; }

    public virtual Hanhkhach? MahkNavigation { get; set; }
}
