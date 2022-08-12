using CleanArch.Application.Features.Commands.DeleteEvent;
using FluentValidation;

namespace CleanArch.Application.Validations.DeleteEvent
{
    public class DeleteTagValidator:AbstractValidator<DeleteTagCommandRequest>
    {
        public DeleteTagValidator()
        {
            RuleFor(pred => pred.Id)
                .NotEmpty();
        }
    }
}
