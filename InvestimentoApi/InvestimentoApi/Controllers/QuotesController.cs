using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestimentoApi.Context;
using InvestimentoApi.Models;
using InvestimentoApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestimentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetQuotes()
        {
            return Ok(_quoteService.GetQuotes());
        }
        
    }
}