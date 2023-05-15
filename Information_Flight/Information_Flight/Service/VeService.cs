namespace Information_Flight.Service;

public interface VeService
{
    public dynamic findByVe(int mahk);

    public int countByVe(int mahk);
    public decimal getAverageVe(int mahk);
}
