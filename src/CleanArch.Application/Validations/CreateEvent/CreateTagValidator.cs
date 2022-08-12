using CleanArch.Application.Features.Commands.CreateEvent;
using CleanArch.Domain.Constants;
using FluentValidation;

namespace CleanArch.Application.Validations.CreateEvent
{
    public class CreateTagValidator:AbstractValidator<CreateTagCommandRequest>
    {
        public CreateTagValidator()
        {
            RuleFor(pred => pred.Description)
                .MinimumLength(1)
                .MaximumLength(20)
                .NotEmpty()
                .WithMessage(ValidationMessages.Tag_Description_Length_Error);

            RuleFor(pred => pred.Name)
                .MinimumLength(1)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage(ValidationMessages.Tag_Name_Length_Error);
        }
    }
}
