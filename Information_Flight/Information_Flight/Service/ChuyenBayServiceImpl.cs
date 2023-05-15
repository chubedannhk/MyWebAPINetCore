using Information_Flight.Models;

namespace Information_Flight.Service;

public class ChuyenBayServiceImpl : ChuyenBayService
{
    private DatabaseContext db;
    public ChuyenBayServiceImpl(DatabaseContext _db)
    {
        db = _db;
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

