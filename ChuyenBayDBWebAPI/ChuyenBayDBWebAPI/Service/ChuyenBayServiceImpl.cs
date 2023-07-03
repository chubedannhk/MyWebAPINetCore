using ChuyenBayDBWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuyenBayDBWebAPI.Service;

public class ChuyenBayServiceImpl : ChuyenBayService
{
    private DatabaseContext db;
    private IConfiguration configuration;
    public ChuyenBayServiceImpl(DatabaseContext _db, IConfiguration _configuration)
    {
        db = _db;
        configuration = _configuration;
    }

    // tao chuyen bay moi
    public bool Created(ChuyenBay chuyenBay)
    {
        try
        {
            db.ChuyenBays.Add(chuyenBay);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public dynamic findAll()
    {

        return db.ChuyenBays.OrderByDescending(p => p.Macb).Select(p => new
        {
            Macb = p.Macb,
            Tencb = p.Tencb,
            Ngaydi = p.Ngaydi,
            Sogheloai1 = p.Sogheloai1,
            Giagheloai1 = p.Giagheloai1,
            Sogheloai2 = p.Sogheloai2,
            Giagheloai2 = p.Giagheloai2,

        }).ToList();
    }

    public bool Update(ChuyenBay chuyenBay)
    {
        try
        {
            db.Entry(chuyenBay).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public dynamic findbyMacb(int macb)
    {
        return db.ChuyenBays.Where(p => p.Macb == macb).Select(p => new
        {
            Macb = p.Macb,
            Tencb = p.Tencb,
            Ngaydi = p.Ngaydi,
            Sogheloai1 = p.Sogheloai1,
            Giagheloai1 = p.Giagheloai1,
            Sogheloai2 = p.Sogheloai2,
            Giagheloai2 = p.Giagheloai2
        }).FirstOrDefault();
    }

    public dynamic findPrice(int macb, int a)
    {
        return db.ChuyenBays.Where(p => p.Macb == macb && a==1).Select(p => new
        {
            //Macb = p.Macb,
            Giagheloai1 = p.Giagheloai1
        }).FirstOrDefault();
    }

    public dynamic findPrice2(int macb, int b)
    {
        return db.ChuyenBays.Where(p => p.Macb == macb && b == 2).Select(p => new
        {
            //Macb = p.Macb,
            Giagheloai2 = p.Giagheloai2
        }).FirstOrDefault();
    }
}
