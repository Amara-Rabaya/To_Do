using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tranning_pro.Models;
using Tranning_pro.Repositories;

namespace Tranning_pro.Controllers
{
    public class CityController : Controller
    {
        private readonly CityRepository _cityRepo;

        public CityController(CityRepository cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public IActionResult Index()
        {
            var cities = _cityRepo.GetAll();
            return View(cities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepo.Insert(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }
        [HttpPost]
        public IActionResult CreateAPI([FromBody] City city)
        {
            try
            {
                var isAdded = _cityRepo.Insert(city);

                if (isAdded)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "City added successfully.",
                        data = city
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Failed to add city."
                    });
                }
            }
            catch (DbUpdateException dbEx)
            {
                // This handles EF Core-specific issues
                return StatusCode(500, new
                {
                    success = false,
                    message = "Database update failed.",
                    error = dbEx.Message
                });
            }
            catch (Exception ex)
            {
                // Generic exception fallback
                return StatusCode(500, new
                {
                    success = false,
                    message = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

    }
}
