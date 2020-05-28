using System;
using System.Collections.Generic;
using Domain.Entities.Base;
using Domain.Enum;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public PersonType Type { get; set; }
        public List<BankAccount> Accounts { get; set; }

    }
}
