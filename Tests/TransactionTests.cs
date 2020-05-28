using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Domain.Entities;
using Infra.Context;
using Infra.Repository;
using Service.Services;
using Template_NetCoreApi_DDD.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class TransactionTests
    {
        [Fact]
        public void DebitTest_OK()
        {
            // MOCK
            var dataBankAccount = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = 1, Agency = 1, Balance = 500, PersonId = 1, Type = Domain.Enum.BankAccountType.Corrente },
                new BankAccount { Id = 2, AccountNumber = 2, Agency = 1, Balance = 1000, PersonId = 2, Type = Domain.Enum.BankAccountType.Corrente },
                new BankAccount { Id = 3, AccountNumber = 3, Agency = 1, Balance = 200, PersonId = 3, Type = Domain.Enum.BankAccountType.Corrente }
            }.AsQueryable();


            var dataBankAccountLaunches = new List<BankAccountLaunches>
            {
                
            }.AsQueryable();

            var mockSetBankAccount = new Mock<DbSet<BankAccount>>();
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.Provider).Returns(dataBankAccount.Provider);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.Expression).Returns(dataBankAccount.Expression);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.ElementType).Returns(dataBankAccount.ElementType);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.GetEnumerator()).Returns(dataBankAccount.GetEnumerator());

            var mockSetBankAccountLaunches = new Mock<DbSet<BankAccountLaunches>>();
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.Provider).Returns(dataBankAccountLaunches.Provider);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.Expression).Returns(dataBankAccountLaunches.Expression);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.ElementType).Returns(dataBankAccountLaunches.ElementType);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.GetEnumerator()).Returns(dataBankAccountLaunches.GetEnumerator());


            var mockContext = new Mock<AppDbContext>();

            mockContext.Setup(c => c.BankAccount).Returns(mockSetBankAccount.Object);
            mockContext.Setup(c => c.Set<BankAccount>()).Returns(mockSetBankAccount.Object);

            mockContext.Setup(c => c.BankAccountLaunches).Returns(mockSetBankAccountLaunches.Object);
            mockContext.Setup(c => c.Set<BankAccountLaunches>()).Returns(mockSetBankAccountLaunches.Object);


            BankAccountRepository bankAccountRepository = new BankAccountRepository(mockContext.Object);

            BankAccountLaunchesRepository bankAccountLaunchesRepository = new BankAccountLaunchesRepository(mockContext.Object);

            BankAccountService bankAccountService =
                new BankAccountService(bankAccountRepository, new Service.Validators.BankAccountValidator());

            BankAccountLaunchesService bankAccountLaunchesService =
                new BankAccountLaunchesService(bankAccountLaunchesRepository, new Service.Validators.BankAccountLaunchesValidator());

            TransactionsService transactionsService = new TransactionsService(bankAccountLaunchesService, bankAccountService);


            var debit = new Domain.ApiEntryModels.Debit(1, 1, 100);

            var bankAccountCurrentBalance = bankAccountService.Get(debit.Agency, debit.AccountNumber).Balance;
            var bankDebit = transactionsService.Debit(debit);

            decimal currentBalanceWithDebit = bankAccountCurrentBalance - debit.Value;
            decimal currentBalance = bankDebit.Result.Balance;

            Assert.Equal(currentBalanceWithDebit, currentBalance);
        }

        [Fact]
        public void CreditTest_OK()
        {
            // MOCK
            var dataBankAccount = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = 1, Agency = 1, Balance = 500, PersonId = 1, Type = Domain.Enum.BankAccountType.Corrente },
                new BankAccount { Id = 2, AccountNumber = 2, Agency = 1, Balance = 1000, PersonId = 2, Type = Domain.Enum.BankAccountType.Corrente },
                new BankAccount { Id = 3, AccountNumber = 3, Agency = 1, Balance = 200, PersonId = 3, Type = Domain.Enum.BankAccountType.Corrente }
            }.AsQueryable();


            var dataBankAccountLaunches = new List<BankAccountLaunches>
            {

            }.AsQueryable();

            var mockSetBankAccount = new Mock<DbSet<BankAccount>>();
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.Provider).Returns(dataBankAccount.Provider);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.Expression).Returns(dataBankAccount.Expression);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.ElementType).Returns(dataBankAccount.ElementType);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.GetEnumerator()).Returns(dataBankAccount.GetEnumerator());

            var mockSetBankAccountLaunches = new Mock<DbSet<BankAccountLaunches>>();
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.Provider).Returns(dataBankAccountLaunches.Provider);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.Expression).Returns(dataBankAccountLaunches.Expression);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.ElementType).Returns(dataBankAccountLaunches.ElementType);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.GetEnumerator()).Returns(dataBankAccountLaunches.GetEnumerator());


            var mockContext = new Mock<AppDbContext>();

            mockContext.Setup(c => c.BankAccount).Returns(mockSetBankAccount.Object);
            mockContext.Setup(c => c.Set<BankAccount>()).Returns(mockSetBankAccount.Object);

            mockContext.Setup(c => c.BankAccountLaunches).Returns(mockSetBankAccountLaunches.Object);
            mockContext.Setup(c => c.Set<BankAccountLaunches>()).Returns(mockSetBankAccountLaunches.Object);


            BankAccountRepository bankAccountRepository = new BankAccountRepository(mockContext.Object);

            BankAccountLaunchesRepository bankAccountLaunchesRepository = new BankAccountLaunchesRepository(mockContext.Object);

            BankAccountService bankAccountService =
                new BankAccountService(bankAccountRepository, new Service.Validators.BankAccountValidator());

            BankAccountLaunchesService bankAccountLaunchesService =
                new BankAccountLaunchesService(bankAccountLaunchesRepository, new Service.Validators.BankAccountLaunchesValidator());

            TransactionsService transactionsService = new TransactionsService(bankAccountLaunchesService, bankAccountService);


            var credit = new Domain.ApiEntryModels.Credit(1, 1, 100);

            var bankAccountCurrentBalance = bankAccountService.Get(credit.Agency, credit.AccountNumber).Balance;
            var bankDebit = transactionsService.Credit(credit);

            decimal currentBalanceWithDebit = bankAccountCurrentBalance + credit.Value;
            decimal currentBalance = bankDebit.Result.Balance;

            Assert.Equal(currentBalanceWithDebit, currentBalance);
        }

        [Fact]
        public void TransferTest_OK()
        {
            // MOCK
            var dataBankAccount = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = 1, Agency = 1, Balance = 500, PersonId = 1, Type = Domain.Enum.BankAccountType.Corrente },
                new BankAccount { Id = 2, AccountNumber = 2, Agency = 1, Balance = 1000, PersonId = 2, Type = Domain.Enum.BankAccountType.Corrente },
                new BankAccount { Id = 3, AccountNumber = 3, Agency = 1, Balance = 200, PersonId = 3, Type = Domain.Enum.BankAccountType.Corrente }
            }.AsQueryable();


            var dataBankAccountLaunches = new List<BankAccountLaunches>
            {

            }.AsQueryable();

            var mockSetBankAccount = new Mock<DbSet<BankAccount>>();
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.Provider).Returns(dataBankAccount.Provider);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.Expression).Returns(dataBankAccount.Expression);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.ElementType).Returns(dataBankAccount.ElementType);
            mockSetBankAccount.As<IQueryable<BankAccount>>().Setup(m => m.GetEnumerator()).Returns(dataBankAccount.GetEnumerator());

            var mockSetBankAccountLaunches = new Mock<DbSet<BankAccountLaunches>>();
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.Provider).Returns(dataBankAccountLaunches.Provider);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.Expression).Returns(dataBankAccountLaunches.Expression);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.ElementType).Returns(dataBankAccountLaunches.ElementType);
            mockSetBankAccountLaunches.As<IQueryable<BankAccountLaunches>>().Setup(m => m.GetEnumerator()).Returns(dataBankAccountLaunches.GetEnumerator());


            var mockContext = new Mock<AppDbContext>();

            mockContext.Setup(c => c.BankAccount).Returns(mockSetBankAccount.Object);
            mockContext.Setup(c => c.Set<BankAccount>()).Returns(mockSetBankAccount.Object);

            mockContext.Setup(c => c.BankAccountLaunches).Returns(mockSetBankAccountLaunches.Object);
            mockContext.Setup(c => c.Set<BankAccountLaunches>()).Returns(mockSetBankAccountLaunches.Object);


            BankAccountRepository bankAccountRepository = new BankAccountRepository(mockContext.Object);

            BankAccountLaunchesRepository bankAccountLaunchesRepository = new BankAccountLaunchesRepository(mockContext.Object);

            BankAccountService bankAccountService =
                new BankAccountService(bankAccountRepository, new Service.Validators.BankAccountValidator());

            BankAccountLaunchesService bankAccountLaunchesService =
                new BankAccountLaunchesService(bankAccountLaunchesRepository, new Service.Validators.BankAccountLaunchesValidator());

            TransactionsService transactionsService = new TransactionsService(bankAccountLaunchesService, bankAccountService);


            var transfer = new Domain.ApiEntryModels.Transfer(1, 1, 1, 2, 200);

            var sourceBankAccountCurrentBalance = bankAccountService.Get(transfer.SourceAgency, transfer.SourceBankAccount).Balance;
            var destinyBankAccountCurrentBalance = bankAccountService.Get(transfer.DestinyAgency, transfer.DestinyBankAccount).Balance;

            var bankTransfer = transactionsService.Transfer(transfer).Result;

            decimal sourceBankAccountCurrentBalanceTransfer = sourceBankAccountCurrentBalance - transfer.Value;
            decimal destinyAccountCurrentBalanceTransfer = destinyBankAccountCurrentBalance + transfer.Value;

            Assert.Equal(sourceBankAccountCurrentBalanceTransfer, bankTransfer.SourceBankAccount.Balance);
            Assert.Equal(destinyAccountCurrentBalanceTransfer, bankTransfer.DestinyBankAccount.Balance);
        }

    }

}
