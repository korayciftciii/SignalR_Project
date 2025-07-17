using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataTransferObject.ContactDTO;

namespace Web.ServiceLayer.ValidationRules.ContactValidations
{
 public   class CreateContactValidation : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidation()
        {
            RuleFor(x => x.FullName)
           .NotEmpty().WithMessage("Full name is required.")
           .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.")
           .MinimumLength(2).WithMessage("Full name must be at least 2 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.")
                .MaximumLength(150).WithMessage("Email must not exceed 150 characters.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Subject is required.")
                .MinimumLength(10).WithMessage("Subject must be at least 10 characters long.")
                .MaximumLength(1000).WithMessage("Subject must not exceed 1000 characters.");

            RuleFor(x => x.ContactDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Contact date cannot be in the future.");
        }
    }
}
