using System;
using System.Collections.Generic;

namespace Information_Flight.Models;

public partial class Chuyenbay
{
    public int Macb { get; set; }

    public string? Tencb { get; set; }

    public int? Masbdi { get; set; }

    public int? Masbden { get; set; }

    public DateTime? Ngaydi { get; set; }

    public int? Gheloai1 { get; set; }

    public decimal? Giagheloai1 { get; set; }

    public int? Gheloai2 { get; set; }

    public decimal? Giagheloai2 { get; set; }

    public virtual ICollection<Chitietchuyenbay> Chitietchuyenbays { get; set; } = new List<Chitietchuyenbay>();

    public virtual Sanbay? MasbdenNavigation { get; set; }

    public virtual Sanbay? MasbdiNavigation { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
