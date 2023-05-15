using Information_Flight.Models;

namespace Information_Flight.Service;

public class VeServiceImpl : VeService
{
    private DatabaseContext db;
    public VeServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    public int countByVe(int mahk)
    {
        var count = db.Ves.Count(p => p.Mahk == mahk);
        return count;
    }

    public dynamic findByVe(int mahk)
    {
        var result = db.Ves
          .Join(db.Chuyenbays, v => v.Macb, cb => cb.Macb, (v, cb) => new { v, cb })
          .Join(db.Hanhkhaches, vcb => vcb.v.Mahk, hk => hk.Mahk, (vcb, hk) => new { vcb, hk })
          .Where(p => p.vcb.v.Mahk == mahk)
          .Select(p => new
          {
              Mave = p.vcb.v.Mave,
              Mahk = p.vcb.v.Mahk,
              Hoten = p.hk.Hoten,
              Macb = p.vcb.v.Macb,
              Tencb = p.vcb.cb.Tencb,
              Soghe = p.vcb.v.Soghe,
              Loaighe = p.vcb.v.Loaighe,
              Giaghe = p.vcb.v.Giaghe
            
          }).ToList();
        return result;
    }

    public decimal getAverageVe(int mahk)
    {
         var sum = db.Ves.Where(p => p.Mahk == mahk).Sum(p => p.Giaghe);
        return (decimal)sum;
    }
}
