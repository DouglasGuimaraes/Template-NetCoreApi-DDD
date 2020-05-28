using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.ApiEntryModels;
using Domain.Entities;
using Infra.Repository;
using Service.Validators;

namespace Service.Services
{
    public class BankAccountService : BaseService<BankAccount, BankAccountRepository, BankAccountValidator>
    {

        public BankAccountService(BankAccountRepository repository, BankAccountValidator validator)
            : base(repository, validator)
        {
            
        }

        public BankAccount Get(int agency, long accountNumber)
        {
            return repository.Get(agency, accountNumber);
        }

    }
}
