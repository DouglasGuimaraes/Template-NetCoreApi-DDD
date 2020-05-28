using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.ApiEntryModels;
using Domain.ApiResultModels;
using Domain.Entities;

namespace Service.Services
{
    public class TransactionsService
    {
        private readonly BankAccountLaunchesService bankAccountLaunchesService;
        private readonly BankAccountService bankAccountService;

        public TransactionsService(BankAccountLaunchesService bankAccountLaunchesService, BankAccountService bankAccountService)
        {
            this.bankAccountLaunchesService = bankAccountLaunchesService;
            this.bankAccountService = bankAccountService;
        }

        public async Task<BankAccount> Debit(Debit debit)
        {
            try
            {
                BankAccount bankAccount = bankAccountService.GetByFilter(x => x.Agency.Equals(debit.Agency) && x.AccountNumber.Equals(debit.AccountNumber)).FirstOrDefault();
                if (bankAccount != null)
                {
                    if (bankAccount.Balance > debit.Value)
                    {
                        bankAccount.Balance -= debit.Value;
                        var upd = await bankAccountService.Put(bankAccount);

                        BankAccountLaunches launch =
                            new BankAccountLaunches(bankAccount.Id, DateTime.Now, Domain.Enum.LaunchType.Debito, debit.Value);
                        AddLaunch(launch);

                        return upd;
                    }
                    else
                    {
                        throw new Exception("Insufficient funds in this respective Bank Account for this operation.");
                    }
                }
                else
                    throw new Exception("Bank Account not found.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BankAccount> Credit(Credit credit)
        {
            try
            {
                BankAccount bankAccount = bankAccountService.GetByFilter(x => x.Agency.Equals(credit.Agency) && x.AccountNumber.Equals(credit.AccountNumber)).FirstOrDefault();
                if (bankAccount != null)
                {
                    bankAccount.Balance += credit.Value;
                    var upd = await bankAccountService.Put(bankAccount);
                    BankAccountLaunches launch =
                            new BankAccountLaunches(bankAccount.Id, DateTime.Now, Domain.Enum.LaunchType.Credito, credit.Value);
                    AddLaunch(launch);
                    return upd;
                }
                else
                    throw new Exception("Bank Account not found.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransferResult> Transfer(Transfer transfer)
        {
            TransferResult result = new TransferResult();
            bool step1 = false,
                 step2 = false;
            decimal sourceBankAccountInitialBalance = -1;
            BankAccount sourceBankAccount;
            BankAccount destinyBankAccount;
            try
            {
                sourceBankAccount = bankAccountService.Get(transfer.SourceAgency, transfer.DestinyAgency);
                                            
                destinyBankAccount = bankAccountService.Get(transfer.DestinyAgency, transfer.DestinyBankAccount);

                if (sourceBankAccount != null && destinyBankAccount != null)
                {
                    if (sourceBankAccount.Balance > transfer.Value)
                    {
                        sourceBankAccountInitialBalance = sourceBankAccount.Balance;

                        sourceBankAccount.Balance -= transfer.Value;
                        destinyBankAccount.Balance += transfer.Value;

                        await bankAccountService.Put(sourceBankAccount);
                        step1 = true;

                        await bankAccountService.Put(destinyBankAccount);
                        step2 = true;

                        BankAccountLaunches launch =
                            new BankAccountLaunches(sourceBankAccount.Id, DateTime.Now, Domain.Enum.LaunchType.Transferencia, transfer.Value, destinyBankAccount.Id);
                        AddLaunch(launch);

                        result.SourceBankAccount = sourceBankAccount;
                        result.DestinyBankAccount = destinyBankAccount;
                    }
                    else
                    {
                        throw new Exception("Insufficient funds in this respective Bank Account for this operation.");
                    }
                }
                else
                {
                    throw new Exception("Invalid Source/Destiny Bank Account.");
                }


                return result;
            }
            catch (Exception ex)
            {
                // Rollback
                if (step1 == true && step2 == false)
                {
                    sourceBankAccount = bankAccountService
                                            .GetByFilter(x => x.Agency.Equals(transfer.SourceAgency) && x.AccountNumber.Equals(transfer.DestinyAgency))
                                            .FirstOrDefault();

                    if (sourceBankAccountInitialBalance != -1)
                        sourceBankAccount.Balance = sourceBankAccountInitialBalance;
                }

                throw ex;
            }
        }

        private async void AddLaunch(BankAccountLaunches bankAccountLaunches)
        {
            await bankAccountLaunchesService.Post(bankAccountLaunches);
        }
    }
}
