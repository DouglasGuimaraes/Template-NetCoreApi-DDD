using System;
using System.Text;
using Domain.Entities;
using Domain.Entities.Abs;
using Domain.Interfaces;

namespace Service.Validators
{
    public class BankAccountValidator : BaseValidator<BankAccount>
    {
        public override ValidatorReturn InsertValidation(BankAccount entity)
        {
            ValidatorReturn validator = new ValidatorReturn();
            StringBuilder sb = new StringBuilder();

            if (entity.Id > 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid id.");
                
            }

            if(entity.Agency <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid Agency Number.");
            }

            if (entity.AccountNumber <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid Account Number.");
            }

            if (entity.PersonId <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid Person.");
            }

            validator.Message = sb.ToString();

            return validator;
        }

        public override ValidatorReturn UpdateValidation(BankAccount entity)
        {
            ValidatorReturn validator = new ValidatorReturn();
            StringBuilder sb = new StringBuilder();

            if (entity.Id <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid id.");

            }

            if (entity.Agency <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid Agency Number.");
            }

            if (entity.AccountNumber <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid Account Number.");
            }

            if (entity.PersonId <= 0)
            {
                validator.Ok = false;
                sb.AppendLine("Invalid Person.");
            }

            validator.Message = sb.ToString();

            return validator;
        }
    }
}
