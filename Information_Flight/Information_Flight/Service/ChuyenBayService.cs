using Information_Flight.Models;

namespace Information_Flight.Service;

public interface ChuyenBayService
{
    public dynamic findAllChuyenBay(DateTime ngaydi);
    //Den so luong ghe chua dat và đã đặt
    public dynamic CountGheByChuyenBay(int macb);
}
