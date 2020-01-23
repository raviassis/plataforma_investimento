using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestimentoApi.Context;
using InvestimentoApi.Controllers.Requests;
using InvestimentoApi.Models;
using InvestimentoApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InvestimentoApi.Shared.Constantes;

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
        public ActionResult GetQuotes()
        {
            return Ok(_quoteService.GetQuotes());
        }

        [HttpGet("own")]
        [Authorize]
        public ActionResult OwnQuotes()
        {
            if (User.HasClaim(c => c.Type == JwtClains.ID))
            {
                var userId = User.FindFirst(JwtClains.ID).Value;
                var result = _quoteService.OwnQuotes(userId);
                return Ok(result);
            }

            return NoContent();
        }

        [HttpPost("buy")]
        [Authorize]
        public ActionResult Buy([FromBody] QuoteRequest request)
        {
            if (User.HasClaim(c => c.Type == JwtClains.ID))
            {
                var userId = User.FindFirst(JwtClains.ID).Value;
                var result = _quoteService.BuyQuote(request.Id, request.Number, userId);
                return Ok(result);
            }

            return NoContent();
        }

        [HttpPost("sell")]
        [Authorize]
        public ActionResult Sell([FromBody] QuoteRequest request)
        {
            if (User.HasClaim(c => c.Type == JwtClains.ID))
            {
                var userId = User.FindFirst(JwtClains.ID).Value;
                var result = _quoteService.SellQuote(request.Id, request.Number, userId);
                return Ok(result);
            }

            return NoContent();
        }

    }
}