using ChuyenBayDBWebAPI.Models;

namespace ChuyenBayDBWebAPI.Service;

public interface ChuyenBayService
{
    public dynamic findAll();
    public bool Created(ChuyenBay chuyenBay);
    public bool Update(ChuyenBay chuyenBay);
    public dynamic findbyMacb(int macb);

    public dynamic findPrice(int macb, int a);
    public dynamic findPrice2(int macb, int b);
}
