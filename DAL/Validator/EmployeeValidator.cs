using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Validator
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            int i = 0;
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.Phone).Must(x => int.TryParse(x, out i)).WithMessage("Phone must be number");
        }
    }
}
