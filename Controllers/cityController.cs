using Microsoft.AspNetCore.Mvc;
using Tranning_pro.Models;
using Tranning_pro.Repositories;

namespace Tranning_pro.Controllers
{
    public class CityController : Controller
    {
        private readonly CityRepository cityRepo;

        public CityController(CityRepository cityRepository)
        {
           // cityRepo = new CityRepository(repo);
           cityRepo = cityRepository;
        }

        // GET: City
        public IActionResult Index()
        {
            var cities = cityRepo.GetAll();
            return View(cities);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                cityRepo.Insert(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }
    }
}
