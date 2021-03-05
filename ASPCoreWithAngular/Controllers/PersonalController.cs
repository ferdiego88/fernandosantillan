using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreWithAngular.Interfaces;
using ASPCoreWithAngular.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class PersonalController : Controller
    {
        private readonly IPersonal objpersonal;

        public PersonalController(IPersonal _objpersonal)
        {
            objpersonal = _objpersonal;
        }

        [HttpGet]
        [Route("Index")]
        public IEnumerable<Personal> Index()
        {
            return objpersonal.GetAllPersonal();
        }

        [HttpPost]
        [Route("Crear")]
        public int Create([FromBody] Personal personal)
        {
            return objpersonal.AddPersonal(personal);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public Personal Details(int id)
        {
            return objpersonal.GetPersonalData(id);
        }

        [HttpPut]
        [Route("Editar")]
        public int Edit([FromBody]Personal personal)
        {
            return objpersonal.UpdatePersonal(personal);
        }

        [HttpDelete]
        [Route("Borrar/{id}")]
        public int Delete(int id)
        {
            return objpersonal.DeletePersonal(id);
        }

        //[HttpGet]
        //[Route("GetCityList")]
        //public IEnumerable<City> Details()
        //{
        //    return objpersonal.GetCities();
        //}
    }
}
