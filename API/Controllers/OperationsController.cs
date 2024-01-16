using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Models
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OperationsController :ControllerBase
    {
        private readonly OperationsContext _dbContext;
        public OperationsController(OperationsContext dbContext)
        {
        _dbContext=dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operations>>> GetComplaint()
        {
            if(_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.Operations.ToListAsync();
        }
        
        [HttpGet("Email")]
        public async Task<ActionResult<Operations>> GetSpecificComplaint(String Email)        {
            if(_dbContext == null)
            {
                return NotFound();
            }
            var Brand=await _dbContext.Operations.FindAsync(Email);
            if(Brand== null)
            {
                return NotFound();
            }
            return Brand;
        }
        [HttpPost]
        public async Task<ActionResult<Operations>>PostComplaint(Operations operations)
        {
            _dbContext.Operations.Add(operations);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComplaint),new {Email =operations.Email}, operations);
        }
        [HttpPut]
        public async Task<IActionResult>PutComplaint(String Email, Operations brand)
        {
            if(Email!= brand.Email)
            {
                return BadRequest();
            }
            _dbContext.Entry(brand).State=EntityState.Modified;
            try
            { 
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!OperationsAvailable(Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

        }
        private bool OperationsAvailable(string Email)
        {
            return(_dbContext.Operations?.Any(x => x.Email==Email)).GetValueOrDefault();
        }

        
        [HttpDelete("Email")]
           public async Task<IActionResult> DeleteComplaint(String Email)        
           {          
            if(_dbContext.Operations == null)
            {
                return NotFound();
            }
            var brand=await _dbContext.Operations.FindAsync(Email);
            if(brand== null)
            {
                return NotFound();
            }
            _dbContext.Operations.Remove(brand);
            await _dbContext.SaveChangesAsync();
            return Ok();
           }
    }

}
  