using System;
using System.Collections.Generic;

namespace Information_Flight.Models;

public partial class Hanhkhach
{
    public int Mahk { get; set; }

    public string? Hoten { get; set; }

    public string? Cmnd { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
