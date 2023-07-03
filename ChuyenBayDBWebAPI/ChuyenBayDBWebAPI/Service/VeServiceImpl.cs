using ChuyenBayDBWebAPI.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ChuyenBayDBWebAPI.Service;

public class VeServiceImpl : VeService
{
    private DatabaseContext db;
    private IConfiguration configuration;
    public VeServiceImpl(DatabaseContext _db, IConfiguration _configuration)
    {
        db = _db;
        configuration = _configuration;
    }
    public bool Created(Ve ve)
    {
        try
        {
            db.Ves.Add(ve);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

  

    public dynamic findAll()
    {
        return db.Ves.Select(p => new
        {
           Mave = p.Mave,
           Hotenhanhkhach = p.Hotenhanhkhach,
           Cmnd = p.Cmnd,
           Macb = p.Macb,
           Loaighe = p.Loaighe,
           Giaghe = p.Giaghe

        }).ToList();
    }

    public dynamic findbyMacb(int macb)
    {
        return db.Ves.Where(p => p.Macb == macb).Select(p => new
        {
            Mave = p.Mave,
            Hotenhanhkhach = p.Hotenhanhkhach,
            Cmnd = p.Cmnd,
            Macb = p.Macb,
            Loaighe = p.Loaighe,
            Giaghe = p.Giaghe

        }).OrderByDescending(p => p.Loaighe).ToList();
    }

    public bool Delete(int mave)
    {
        try
        {
            db.Ves.Remove(db.Ves.Find(mave));
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public dynamic searchByLoaighe(int macb, int loaighe)
    {
        return db.Ves.Where(p => p.Macb == macb && p.Loaighe == loaighe).Select(p => new
        {
            Mave = p.Mave,
            Hotenhanhkhach = p.Hotenhanhkhach,
            Cmnd = p.Cmnd,
            Macb = p.Macb,
            Loaighe = p.Loaighe,
            Giaghe = p.Giaghe
        }).OrderByDescending(p => p.Giaghe).ToList();
    }

    public dynamic searchByGiaghe(int macb, int giaghe)
    {
        return db.Ves.Where(p => p.Macb == macb && p.Giaghe <= giaghe).Select(p => new
        {
            Mave = p.Mave,
            Hotenhanhkhach = p.Hotenhanhkhach,
            Cmnd = p.Cmnd,
            Macb = p.Macb,
            Loaighe = p.Loaighe,
            Giaghe = p.Giaghe
        }).OrderByDescending(p => p.Giaghe).ToList();
    }
}
