using System;
using Domain.Entities;
using Infra.Context;

namespace Infra.Repository
{
    public class BankAccountLaunchesRepository : BaseRepository<BankAccountLaunches, AppDbContext>
    {
        public BankAccountLaunchesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
