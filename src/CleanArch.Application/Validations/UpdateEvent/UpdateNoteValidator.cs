using CleanArch.Application.Features.Commands.UpdateEvent;
using CleanArch.Domain.Constants;
using FluentValidation;

namespace CleanArch.Application.Validations.UpdateEvent
{
    public class UpdateNoteValidator : AbstractValidator<UpdateNoteCommandRequest>
    {
        public UpdateNoteValidator()
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

            RuleFor(pred => pred.Id)
                .NotEmpty()
                .WithMessage(ValidationMessages.Entity_Required_Id_Error);

            RuleFor(pred => pred.IsStarred)
                .NotEmpty()
                .Must(x => x == true || x == false)
                .WithMessage(ValidationMessages.Note_IsFavorited_Error);
        }
    }
}
