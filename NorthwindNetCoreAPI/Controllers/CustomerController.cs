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
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CustomerController(NorthwindDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> TestingUp()
        {
            var a = unitOfWork.CustomersRepository.Get().ToList();
            return Ok("Great!");
        }
    }
}
