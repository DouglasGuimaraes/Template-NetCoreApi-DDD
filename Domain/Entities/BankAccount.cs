using System;
using Domain.Entities.Base;
using Domain.Enum;

namespace Domain.Entities
{
    /// <summary>
    /// Classe de Conta Corrente
    /// </summary>
    public class BankAccount : BaseEntity
    {
        public virtual int PersonId { get; set; }
        
        public virtual BankAccountType Type { get; set; }
        public virtual int Agency { get; set; }
        public virtual long AccountNumber { get; set; }
        public virtual decimal Balance { get; set; }
    }
}
