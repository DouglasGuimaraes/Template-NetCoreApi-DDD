using System;
namespace Domain.ApiEntryModels
{
    public class Transfer
    {
        public Transfer(int sourceAgency,long sourceBankAccount, int destinyAgency, long destinyBankAccount, decimal value)
        {
            this.SourceAgency = sourceAgency;
            this.SourceBankAccount = sourceBankAccount;
            this.DestinyAgency = destinyAgency;
            this.DestinyBankAccount = destinyBankAccount;
            this.Value = value;
        }

        public int SourceAgency { get; set; }
        public long SourceBankAccount { get; set; }
        public int DestinyAgency { get; set; }
        public long DestinyBankAccount { get; set; }
        public decimal Value { get; set; }
    }
}
