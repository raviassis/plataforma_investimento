using FluentAssertions;
using InvestimentoApi.Models;
using InvestimentoApi.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Xunit;
using static InvestimentoApi.Shared.Constantes;

namespace Investimento.UnitTests.Services
{
    public class TestsTokenService
    {
        private readonly TokenService tokenService;
        private readonly Mock<IConfiguration> configurationMock;
        public TestsTokenService()
        {
            configurationMock = new Mock<IConfiguration>();
            tokenService = new TokenService(configurationMock.Object);
        }

        [Fact]
        public void GenerateToken()
        {
            configurationMock.Setup(c => c["JWT:key"]).Returns(Guid.NewGuid().ToString());
            var email = "ravi@gmail.com";
            var id = Guid.NewGuid().ToString();
            var emailClaim = new Claim(JwtClains.EMAIL, email);
            var idClaim = new Claim(JwtClains.ID, id);

            var jwt = tokenService.GenerateToken(id, email);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            token.Claims.Should().ContainEquivalentOf(emailClaim);
            token.Claims.Should().ContainEquivalentOf(idClaim);
        }
    }
}
