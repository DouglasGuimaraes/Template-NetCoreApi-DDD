using System;
namespace Domain.Entities.Abs
{
    public class ValidatorReturn
    {
        public ValidatorReturn()
        {
            Ok = true;
        }

        public bool Ok { get; set; }
        public string Message { get; set; }
    }
}
