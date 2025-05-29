using DAL.ModelsNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICityRepositoryDAL
    {
        List<CityDAL> GetAll ();
        bool Insert (CityDAL city);
        bool Edit (CityDAL city);
        bool Delete (int id);

    }
}
