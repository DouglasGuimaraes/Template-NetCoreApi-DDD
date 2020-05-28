using System;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Repository;
using Service.Validators;

namespace Service.Services
{
    public class BankAccountLaunchesService :
        BaseService<BankAccountLaunches, BankAccountLaunchesRepository, BankAccountLaunchesValidator>
    {

        public BankAccountLaunchesService(BankAccountLaunchesRepository repository, BankAccountLaunchesValidator validator)
            : base(repository, validator)
        {

        }
    }
}
