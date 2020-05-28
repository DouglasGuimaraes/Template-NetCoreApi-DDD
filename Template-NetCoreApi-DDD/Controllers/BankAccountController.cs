using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Template_NetCoreApi_DDD.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Template_NetCoreApi_DDD.Controllers
{
    [Route("api/[controller]")]
    public class BankAcountController
        : BaseController<BankAccount, BankAccountRepository>
    {
        public BankAcountController(BankAccountRepository repository)
            : base(repository)
        {
        }

        
    }
}
