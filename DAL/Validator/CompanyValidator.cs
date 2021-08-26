using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Validator
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
