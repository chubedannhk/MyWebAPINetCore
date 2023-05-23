using Information_Flight.Models;

namespace Information_Flight.Service;

public class ChuyenBayServiceImpl : ChuyenBayService
{
    private DatabaseContext db;
    public ChuyenBayServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    public dynamic CountGheByChuyenBay(int macb)
    {
        var result = db.Chuyenbays
        .Where(cb => cb.Macb == macb)
        .Select(cb => new
        {
            Macb = cb.Macb,
            Tencb = cb.Tencb,
            SoGheTrongLoai1 = cb.Gheloai1 - db.Ves.Where(v => v.Macb == macb && v.Loaighe == 1).Sum(v => v.Soghe),
            SoGheTrongLoai2 = cb.Gheloai2 - db.Ves.Where(v => v.Macb == macb && v.Loaighe == 2).Sum(v => v.Soghe),
            SoGheDatLoai1 = db.Ves.Where(v => v.Macb == macb && v.Loaighe == 1).Sum(v => v.Soghe),
            SoGheDatLoai2 = db.Ves.Where(v => v.Macb == macb && v.Loaighe == 2).Sum(v => v.Soghe)
        })
        .FirstOrDefault();

        return result;
    }

    public dynamic findAllChuyenBay(DateTime ngaydi)
    {
        
        return db.Chuyenbays
            .Where(p => p.Ngaydi == ngaydi.Date)
            .Select(p => new
        {
            Macb = p.Macb,
            Tencb = p.Tencb,
            Masbdi = p.Masbdi,
            Masbden = p.Masbden,
            Ngaydi = p.Ngaydi,
            Gheloai1 = p.Gheloai1,
            Giagheloai1 = p.Giagheloai1,
            Gheloai2 = p.Gheloai2,
            Giagheloai2 = p.Giagheloai2
        }).ToList();
    }
}

