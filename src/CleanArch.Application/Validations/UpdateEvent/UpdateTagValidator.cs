using CleanArch.Application.Features.Commands.UpdateEvent;
using CleanArch.Domain.Constants;
using FluentValidation;

namespace CleanArch.Application.Validations.UpdateEvent
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagCommandRequest>
    {
        public UpdateTagValidator()
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

            RuleFor(pred => pred.Id)
               .NotEmpty()
               .WithMessage(ValidationMessages.Entity_Required_Id_Error);
        }
    }
}
