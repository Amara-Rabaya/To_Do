using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tranning_pro.Models;
using DAL.ModelsNew;
using DAL.Repositories;
using Tranning_pro.BL;
using Tranning_pro.BLInterface;

namespace Tranning_pro.Controllers
{ 
[Route ("City")]

    public class CityController : Controller
    {
        private readonly ICityBLServece _cityRepo;

        public CityController(ICityBLServece cityRepo)
        {
            _cityRepo = cityRepo;
        }

       

        

        [HttpPost]
        public IActionResult Create([FromBody] CityDAL city)
        {
            if (ModelState.IsValid)
            {
                _cityRepo.addCity(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }
        
        [HttpPost("CreateAPI")]
        public IActionResult CreateAPI([FromBody] CityDAL city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid city data.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            try
            {
                var isAdded = _cityRepo.addCity(city);

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
                return StatusCode(500, new
                {
                    success = false,
                    message = "Database update failed.",
                    error = dbEx.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }
        /// <summary>
        /// Edit Cities
        /// </summary>
        [HttpPut("EditAPI")]
        public IActionResult EditAPI([FromBody] CityDAL city)
        {
            try
            {
                var isEdited = _cityRepo.updateCity(city);

                if (isEdited)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "City updated successfully.",
                        data = city
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "City not found or update failed."
                    });
                }
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Database update failed.",
                    error = dbEx.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }
        /// <summary>
        /// return all Cities
        /// </summary>
        /// <param name="Test">
        /// no Parameter for this API 
        /// </param>
        /// <returns> return list of cities as json </returns>
        [HttpGet("GetAllAPI")]
        public IActionResult GetAllAPI()
        {
            try
            {
                var cities = _cityRepo.gitAll();

                if (cities == null || !cities.Any())
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "No cities found."
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Cities retrieved successfully.",
                    data = cities
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }
        [HttpDelete("DeleteAPI/{id}")]
        public IActionResult DeleteAPI(int id)
        {
            try
            {
                var isDeleted = _cityRepo.deleteCity(id);

                if (isDeleted)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "City deleted successfully."
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "City not found or delete failed."
                    });
                }
            }
            catch (Exception ex)
            {

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
