using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext()
        {

        }

        public virtual DbSet<BankAccount> BankAccount { get; set; }

        public virtual DbSet<BankAccountLaunches> BankAccountLaunches { get; set; }

    }
}
