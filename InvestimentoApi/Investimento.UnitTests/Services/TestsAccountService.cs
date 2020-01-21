using FluentAssertions;
using InvestimentoApi.Context;
using InvestimentoApi.Models;
using InvestimentoApi.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Xunit;

namespace Investimento.UnitTests.Services
{
    public class TestsAccountService
    {
        private readonly AccountService _accountService;
        private Mock<ApplicationDbContext> _contextMock;
        private Mock<DbSet<Account>> _dbSetMock;
        public TestsAccountService()
        {
            _dbSetMock = new Mock<DbSet<Account>>();
            _contextMock = new Mock<ApplicationDbContext>();
            _accountService = new AccountService(_contextMock.Object);
        }

        [Fact]
        public void GetAccount()
        {
            var userId = Guid.NewGuid().ToString();
            var expected = new Account() { Id = Guid.NewGuid().ToString(), UserId = userId };

            //_contextMock.Setup(c => c.Accounts).Returns(_dbSetMock.Object);
            //_dbSetMock.Setup(db => db.Find(It.IsAny<Expression<Func<Account, bool>>>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync( (Account a) => {
            //        a.Id = expected.Id;
            //        a.UserId = expected.UserId;
            //        return a; 
            //    });
            
            var account = _accountService.GetAccount(userId);

            account.Should().BeEquivalentTo(expected);
        }
    }
}
