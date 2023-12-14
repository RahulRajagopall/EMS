using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CrudOperations.models
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class BrandController:ControllerBase
    {
        private readonly BrandContext _dbContext;
        public BrandController(BrandContext dbContext)
        {
        _dbContext=dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetComplaint()
        {
            if(_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.Brands.ToListAsync();
        }
        [HttpGet("Email")]
        public async Task<ActionResult<Brand>> GetSpecificComplaint(String Email)        {
            if(_dbContext == null)
            {
                return NotFound();
            }
            var Brand=await _dbContext.Brands.FindAsync(Email);
            if(Brand== null)
            {
                return NotFound();
            }
            return Brand;
        }
        [HttpPost]
        public async Task<ActionResult<Brand>>PostComplaint(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComplaint),new {Email =brand.Email}, brand);
        }
        [HttpPut]
        public async Task<IActionResult>PutComplaint(String Email, Brand brand)
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
                if(!BrandAvailable(Email))
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
        private bool BrandAvailable(string Email)
        {
            return(_dbContext.Brands?.Any(x => x.Email==Email)).GetValueOrDefault();
        }

        
        [HttpDelete("Email")]
           public async Task<IActionResult> DeleteComplaint(String Email)        
           {          
            if(_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand=await _dbContext.Brands.FindAsync(Email);
            if(brand== null)
            {
                return NotFound();
            }
            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
            return Ok();
           }
    }

}
