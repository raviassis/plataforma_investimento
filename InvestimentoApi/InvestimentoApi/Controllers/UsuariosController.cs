using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InvestimentoApi.Context;
using InvestimentoApi.Models;
using InvestimentoApi.Services.Interfaces;
using InvestimentoApi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InvestimentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbContext _context;

        public UsuariosController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IConfiguration configuration,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return " << Controlador UsuariosController :: WebApiUsuarios >> ";
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<UserViewModel>> CreateUser([FromBody] UserInfo model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var account = _context.Accounts.FirstOrDefault(a => a.UserId == user.Id);
                if (account == null)
                {
                    account = new Account() {Id = Guid.NewGuid().ToString(), User = user, UserId = user.Id };
                    _context.Accounts.Add(account);
                    _context.SaveChanges();
                }
                
                var jwt =  _tokenService.GenerateToken(user.Id, user.Email);
                return new UserViewModel() { Id = user.Id, Email = model.Email, Token = jwt };
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserViewModel>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = _userManager.Users.First(u => u.Email == userInfo.Email);
                var jwt = _tokenService.GenerateToken(user.Id, user.Email);
                return new UserViewModel() {Id = user.Id, Email = user.Email, Token = jwt };
            }
            else
            {
                ModelState.AddModelError("message", "login inválido.");
                return Unauthorized(ModelState);
            }
        }
    }
}