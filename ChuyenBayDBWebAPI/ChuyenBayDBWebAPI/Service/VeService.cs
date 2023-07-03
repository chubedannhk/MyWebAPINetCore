using ChuyenBayDBWebAPI.Models;

namespace ChuyenBayDBWebAPI.Service;

public interface VeService
{
    public dynamic findAll();
    public dynamic findbyMacb(int macb);
    public bool Created(Ve ve);
    public bool Delete(int mave);
    public dynamic searchByLoaighe(int macb, int loaighe);
    public dynamic searchByGiaghe(int macb, int giaghe);
}
