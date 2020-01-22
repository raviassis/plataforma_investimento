using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestimentoApi.Context;
using InvestimentoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestimentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public QuotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetQuotes()
        {
            return Ok( _context.Quotes.ToList());
        }
        
    }
}