using DAL.ModelsNew;

namespace Tranning_pro.BLInterface
{
    public interface ICityBLServece
    {
        List<CityDAL> gitAll();
        bool addCity(CityDAL city);
        bool updateCity(CityDAL city);
        bool deleteCity(int id);


    }
}
