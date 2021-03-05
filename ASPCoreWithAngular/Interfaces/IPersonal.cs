using ASPCoreWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Interfaces
{
    public interface IPersonal
    {
        IEnumerable<Personal> GetAllPersonal();
        int AddPersonal(Personal personal);
        int UpdatePersonal(Personal personal); 
        Personal GetPersonalData(int id);
        int DeletePersonal(int id);
       // List<City> GetCities();
    }
}
