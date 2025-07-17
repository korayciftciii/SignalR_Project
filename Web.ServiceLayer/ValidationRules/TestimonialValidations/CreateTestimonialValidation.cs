using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataTransferObject.TestimonialDTO;

namespace Web.ServiceLayer.ValidationRules.TestimonialValidations
{
   public class CreateTestimonialValidation :AbstractValidator<CreateTestimonialDto>
    {
        public CreateTestimonialValidation()
        {
            RuleFor(x => x.CustomerFullName)
           .NotEmpty().WithMessage("Customer full name is required.")
           .MaximumLength(100).WithMessage("Customer name must not exceed 100 characters.")
           .MinimumLength(2).WithMessage("Customer name must be at least 2 characters long.");

            RuleFor(x => x.Title)
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Title));

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment cannot be empty.")
                .MinimumLength(10).WithMessage("Comment must be at least 10 characters.")
                .MaximumLength(1000).WithMessage("Comment must not exceed 1000 characters.");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(300).WithMessage("Image URL must not exceed 300 characters.")
                .Matches(@"^(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|jpeg|png)$")
                .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl))
                .WithMessage("Image URL must be a valid image path (.jpg, .jpeg, .png)");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Created date cannot be in the future.");
        }
    }
}
