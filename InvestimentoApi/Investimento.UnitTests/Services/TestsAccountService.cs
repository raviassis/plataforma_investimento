using FluentAssertions;
using InvestimentoApi.Context;
using InvestimentoApi.Models;
using InvestimentoApi.Services;
using InvestimentoApi.Shared;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private Mock<IQueryableExtensionWrapper> _queryableMock;
        private Mock<DbSet<Account>> _dbSetMock;
        public TestsAccountService()
        {
            _dbSetMock = new Mock<DbSet<Account>>();
            _contextMock = new Mock<ApplicationDbContext>();
            _queryableMock = new Mock<IQueryableExtensionWrapper>();
            _accountService = new AccountService(_contextMock.Object, _queryableMock.Object);
        }

        [Fact]
        public void GetAccount()
        {
            var userId = Guid.NewGuid().ToString();
            var expected = new Account() { Id = Guid.NewGuid().ToString(), UserId = userId };

            _queryableMock.Setup(q => q.FirstOrDefault(It.IsAny<IQueryable<Account>>(), It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(expected);

            var account = _accountService.GetAccount(userId);

            account.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Deposit()
        {
            var userId = Guid.NewGuid().ToString();
            var depositValue = 1000M;
            var expected = new Account() { Id = Guid.NewGuid().ToString(), UserId = userId };

            _queryableMock.Setup(q => q.FirstOrDefault(It.IsAny<IQueryable<Account>>(), It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(expected);

            _contextMock.Setup(c => c.Accounts).Returns(_dbSetMock.Object);            

            var account = _accountService.Deposit(userId, expected.Id, depositValue);

            _dbSetMock.Verify(d => d.Update(It.IsAny<Account>()));

            account.Balance.Should().Be(depositValue);
        }

        [Fact]
        public void DrawOut()
        {
            var userId = Guid.NewGuid().ToString();
            var depositValue = 1000M;
            var balance = 5000M;
            var expected = 4000M;
            var returnDb = new Account(Guid.NewGuid().ToString(), balance, userId, null );

            _queryableMock.Setup(q => q.FirstOrDefault(It.IsAny<IQueryable<Account>>(), It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(returnDb);
            _contextMock.Setup(c => c.Accounts).Returns(_dbSetMock.Object);

            var account = _accountService.DrawOut(userId, returnDb.Id, depositValue);

            _dbSetMock.Verify(d => d.Update(It.IsAny<Account>()));

            account.Balance.Should().Be(expected);
        }
    }
}
