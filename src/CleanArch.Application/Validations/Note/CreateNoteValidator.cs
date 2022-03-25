using CleanArch.Application.Commands.Note.CreateNote;
using CleanArch.Domain.Constants;
using FluentValidation;

namespace CleanArch.Application.Validations.Note
{
    public class CreateNoteValidator:AbstractValidator<CreateNoteCommandRequest>
    {
        public CreateNoteValidator()
        {
            RuleFor(pred => pred.Content)
                .MinimumLength(1)
                .MaximumLength(500)
                .NotEmpty();

            RuleFor(pred => pred.Title)
                .MinimumLength(1)
                .MinimumLength(25)
                .NotEmpty();
        }
    }
}
