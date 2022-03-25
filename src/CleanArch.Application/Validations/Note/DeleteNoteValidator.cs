using CleanArch.Application.Commands.Note.DeleteNote;
using FluentValidation;

namespace CleanArch.Application.Validations.Note
{
    public class DeleteNoteValidator:AbstractValidator<DeleteNoteCommandRequest>
    {
        public DeleteNoteValidator()
        {
            RuleFor(pred => pred.Id)
                .NotEmpty();
        }
    }
}
