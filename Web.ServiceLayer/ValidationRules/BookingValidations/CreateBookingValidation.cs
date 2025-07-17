using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataTransferObject.ReservationDTO;

namespace Web.ServiceLayer.ValidationRules.BookingValidations
{
public  class CreateBookingValidation : AbstractValidator<CreateReservationDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.CustomerName)
         .NotNull().WithMessage("Customer name cannot be null.")
         .NotEmpty().WithMessage("Customer name cannot be empty.")
         .MinimumLength(2).WithMessage("Customer name must be at least 2 characters long.")
         .MaximumLength(50).WithMessage("Customer name must not exceed 50 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("Phone number cannot be null.")
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .Matches(@"^\+?[0-9\s\-]{7,15}$").WithMessage("Phone number format is invalid.");

            RuleFor(x => x.UserMail)
                .NotNull().WithMessage("User mail cannot be null.")
                .NotEmpty().WithMessage("User mail cannot be empty.")
                .EmailAddress().WithMessage("User mail must be a valid email address.");

            RuleFor(x => x.NumberOfCustomer)
                .NotNull().WithMessage("Number of customers cannot be null.")
                .GreaterThan(0).WithMessage("Number of customers must be greater than 0.");

            RuleFor(x => x.ReservationDate)
                .NotNull().WithMessage("Reservation date cannot be null.")
                .GreaterThan(DateTime.UtcNow).WithMessage("Reservation date must be in the future.");


        }
    }
}
