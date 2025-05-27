using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.ModelsNew;
using Tranning_pro.BLInterface;

namespace Tranning_pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private readonly ICitizenBLService _citizenService;

        public CitizenController(ICitizenBLService citizenService)
        {
            _citizenService = citizenService;
        }

        // GET: api/citizen
        [HttpGet]
        public async Task<ActionResult<List<Citizen>>> GetAll()
        {
            try
            {
                var citizens = await _citizenService.GetAllCitizensAsync();
                return Ok(citizens);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/citizen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Citizen>> GetById(int id)
        {
            try
            {
                var citizen = await _citizenService.GetCitizenByIdAsync(id);
                if (citizen == null)
                {
                    return NotFound($"Citizen with id {id} not found.");
                }
                return Ok(citizen);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/citizen
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Citizen citizen)
        {
            try
            {
                if (citizen == null)
                {
                    return BadRequest("Citizen object is null.");
                }

                bool added = await _citizenService.AddCitizenAsync(citizen);
                if (!added)
                {
                    return BadRequest("Failed to add citizen.");
                }
                return CreatedAtAction(nameof(GetById), new { id = citizen.Id }, citizen);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/citizen/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Citizen citizen)
        {
            try
            {
                if (citizen == null || id != citizen.Id)
                {
                    return BadRequest("Citizen data is invalid.");
                }

                bool updated = await _citizenService.UpdateCitizenAsync(id, citizen);
                if (!updated)
                {
                    return NotFound($"Citizen with id {id} not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/citizen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool deleted = await _citizenService.DeleteCitizenAsync(id);
                if (!deleted)
                {
                    return NotFound($"Citizen with id {id} not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
