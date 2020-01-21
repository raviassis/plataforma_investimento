using InvestimentoApi.Context;
using InvestimentoApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using static InvestimentoApi.Shared.Constantes;

namespace InvestimentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        public AccountController(ApplicationDbContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }
        [HttpGet]
        [Authorize]
        public ActionResult GetAccount()
        {
            if (User.HasClaim(c => c.Type == JwtClains.ID))
            {
                var userId = User.FindFirst(JwtClains.ID).Value;
                var result = _accountService.GetAccount(userId);
                return Ok(result);
            }
            
            return NoContent();
            
        }

        [HttpPost("deposit")]
        [Authorize]
        public ActionResult Deposit(string id, decimal value)
        {
            if(User.HasClaim(c => c.Type == JwtClains.ID))
            {
                var userId = User.FindFirst(JwtClains.ID).Value;

                try
                {
                    var result = _accountService.Deposit(userId, id, value);
                    return Ok(result);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(nameof(e.Message), e.Message);
                    return BadRequest(ModelState);
                }
                
            }

            return NoContent();
        }
    }
}