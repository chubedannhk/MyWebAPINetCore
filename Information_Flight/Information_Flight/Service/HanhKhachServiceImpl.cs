using Information_Flight.Models;

namespace Information_Flight.Service;

public class HanhKhachServiceImpl : HanhKhachService
{
    private DatabaseContext db;
    public HanhKhachServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public dynamic findByHoTen(string hoTen)
    {
        var result = db.Hanhkhaches
            .Where(p => p.Hoten.Contains(hoTen))
            .Select(p => new
            {
                Mahk = p.Mahk,
                Hoten = p.Hoten,
                Cmnd = p.Cmnd,
                Ngaysinh = p.Ngaysinh
            }).ToList();
        return result;
    }
}
