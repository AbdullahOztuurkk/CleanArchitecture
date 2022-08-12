using CleanArch.Application.Features.Commands.CreateEvent;
using CleanArch.Domain.Constants;
using FluentValidation;

namespace CleanArch.Application.Validations.DeleteEvent
{
    public class CreateNoteValidator:AbstractValidator<CreateNoteCommandRequest>
    {
        public CreateNoteValidator()
        {
            RuleFor(pred => pred.Content)
                .MinimumLength(1)
                .MaximumLength(500)
                .NotEmpty()
                .WithMessage(ValidationMessages.Note_Content_Length_Error);

            RuleFor(pred => pred.Title)
                .MinimumLength(1)
                .MinimumLength(25)
                .NotEmpty()
                .WithMessage(ValidationMessages.Note_Title_Length_Error);
        }
    }
}
