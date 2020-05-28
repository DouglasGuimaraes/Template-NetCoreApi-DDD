using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;

namespace Infra.Repository
{
    public class BankAccountRepository : BaseRepository<BankAccount, AppDbContext>
    {
        public BankAccountRepository(AppDbContext context) : base(context)
        {
        }

        public virtual BankAccount Get(int agency, long accountNumber)
        {
            return context.Set<BankAccount>().FirstOrDefault(x => x.Agency == agency && x.AccountNumber == accountNumber);
        }
    }
}
