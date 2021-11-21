using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindDAL;
using NorthwindDatabase.Context;

namespace NorthwindNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected NorthwindDBContext _context;

        public CustomerController(NorthwindDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> TestingUp()
        {
            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                try
                {
                    var response = unitOfWork.CustomersRepository.Get().ToList();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest("Epic Error!");
                }
            }
        }
    }
}
