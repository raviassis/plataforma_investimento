using FluentAssertions;
using InvestimentoApi.Exceptions;
using InvestimentoApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Investimento.UnitTests.Models
{
    public class TestAccount
    {
        [Theory]
        [MemberData(nameof(Deposits))]
        public void Deposit(decimal value, Account account, decimal expected)
        {
            account.Deposit(value);
            account.Balance.Should().Be(expected);
        }

        [Fact]
        public void DepositNegativeValue()
        {
            var account = new Account(Guid.NewGuid().ToString(), 200M, null, null);
            var depositValue = -100M;
            Action act = () => account.Deposit(depositValue);
            act.Should().Throw<NegativeDepositException>();
        }

        public static List<object[]> Deposits => new List<object[]>
        {
            new object[]
            {
                100.40M,
                new Account(Guid.NewGuid().ToString(), 100, string.Empty , null),
                200.40M
            },
            new object[]
            {
                40000M,
                new Account(),
                40000M
            }
        };
    }
}
