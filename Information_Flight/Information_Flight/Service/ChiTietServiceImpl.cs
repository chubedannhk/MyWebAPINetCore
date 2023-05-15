using Information_Flight.Models;

namespace Information_Flight.Service;

public class ChiTietServiceImpl : ChiTietService
{
    private DatabaseContext db;
    public ChiTietServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public dynamic findIdChiTietChuyenBay(int mact)
    {
        var result = db.Chitietchuyenbays
        .Join(db.Chuyenbays, ct => ct.Macb, cb => cb.Macb, (ct, cb) => new { ct, cb })
        .Join(db.Sanbays, ctcb => ctcb.ct.Masb, sb => sb.Masanbay, (ctcb, sb) => new { ctcb, sb })
        .Where(p => p.ctcb.ct.Mact == mact)
        .Select(p => new
        {
            Mact = p.ctcb.ct.Mact,
            Macb = p.ctcb.ct.Macb,
            Tencb = p.ctcb.cb.Tencb,
            Masb = p.ctcb.ct.Masb,
            Tensb = p.sb.Tensanbay,
            Thoigiandung = p.ctcb.ct.Thoigiandung,
            Moto = p.ctcb.ct.Moto
        }).ToList();

       // var json = JsonConvert.SerializeObject(result);
        return result;
    }
}
