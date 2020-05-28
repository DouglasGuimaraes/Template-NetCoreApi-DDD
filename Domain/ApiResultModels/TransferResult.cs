using System;
using Domain.Entities;

namespace Domain.ApiResultModels
{
    public class TransferResult
    {
        public BankAccount SourceBankAccount { get; set; }

        public BankAccount DestinyBankAccount { get; set; }
    }
}
