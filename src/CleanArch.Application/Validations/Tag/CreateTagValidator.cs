using CleanArch.Application.Features.Commands.CreateEvent;
using FluentValidation;

namespace CleanArch.Application.Validations.Tag
{
    public class CreateTagValidator:AbstractValidator<CreateTagCommandRequest>
    {
        public CreateTagValidator()
        {
            RuleFor(pred => pred.Description)
                .MinimumLength(1)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(pred => pred.Name)
                .MinimumLength(1)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
