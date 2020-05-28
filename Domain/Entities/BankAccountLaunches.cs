using System;
using Domain.Entities.Base;
using Domain.Enum;

namespace Domain.Entities
{
    /// <summary>
    /// Classe de Lançamentos
    /// </summary>
    public class BankAccountLaunches : BaseEntity
    {

        public BankAccountLaunches()
        {

        }

        public BankAccountLaunches(int sourceBankAccountId, DateTime date, LaunchType type, decimal LaunchValue, int destinyBankAccountId = 0)
        {
            this.SourceBankAccountId = sourceBankAccountId;
            this.Date = date;
            this.Type = type;
            this.LaunchValue = LaunchValue;
            this.DestinyBankAccountId = destinyBankAccountId;
        }

        public int SourceBankAccountId { get; set; }
        public BankAccount SourceBankAccountIdBankAccount { get; set; }

        public int? DestinyBankAccountId { get; set; }
        public BankAccount DestinyBankAccount { get; set; }

        public DateTime Date { get; set; }
        public LaunchType Type { get; set; }
        public decimal LaunchValue { get; set; }
    }
}
