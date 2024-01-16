// using System;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// namespace API.Models;
// {
//     [Route("api/[controller]/[Action]")]
//     [ApiController]
//     private readonly OperationsContext _dbContext;
//         public LoginController(OperationsContext dbContext)
//         {
//         _dbContext=dbContext;
//         }
//         public async Task<ActionResult<IEnumerable<Operations>>> GetData()
//         {
//             if(_dbContext == null)
//             {
//                 return NotFound();
//             }
//             return await _dbContext.Operations.ToListAsync();
//         }
//         [HttpPost]
//         public async Task<ActionResult<Operations>>Register(Operations operations)
//         {
//             _dbContext.Operations.Add(operations);
//             await _dbContext.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetData),new {Email =operations.Email}, operations);
//         }
}
