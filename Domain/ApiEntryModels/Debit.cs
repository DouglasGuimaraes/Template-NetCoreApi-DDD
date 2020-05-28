using System;
namespace Domain.ApiEntryModels
{
    public class Debit
    {
        public Debit()
        {

        }

        public Debit(int agency, long accountNumber, decimal value)
        {
            this.AccountNumber = accountNumber;
            this.Agency = agency;
            this.Value = value;
        }

        public int Agency { get; set; }
        public long AccountNumber { get; set; }
        public decimal Value { get; set; }
    }
}
