using System;
using System.Text;
using Domain.Entities;
using Domain.Entities.Abs;

namespace Service.Validators
{
    public class BankAccountLaunchesValidator : BaseValidator<BankAccountLaunches>
    {
        public override ValidatorReturn InsertValidation(BankAccountLaunches entity)
        {
            ValidatorReturn validator = new ValidatorReturn();
            StringBuilder sb = new StringBuilder();

            if (entity.Id > 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid id.");

            }

            if (entity.SourceBankAccountId <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid Bank Account.");
            }

            if (entity.LaunchValue <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid finacial value.");
            }

            if (entity.Date >= DateTime.Now)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid Date.");
            }

            validator.Message = sb.ToString();

            return validator;
        }

        public override ValidatorReturn UpdateValidation(BankAccountLaunches entity)
        {
            throw new Exception("Update not authorized for bank account launches.");
        }
    }
}
