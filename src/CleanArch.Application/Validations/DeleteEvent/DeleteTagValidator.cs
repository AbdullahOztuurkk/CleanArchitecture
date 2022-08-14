using CleanArch.Application.Features.Commands.DeleteEvent;
using CleanArch.Domain.Constants;
using FluentValidation;

namespace CleanArch.Application.Validations.DeleteEvent
{
    public class DeleteTagValidator:AbstractValidator<DeleteTagCommandRequest>
    {
        public DeleteTagValidator()
        {
            RuleFor(pred => pred.Id)
                .NotEmpty()
                .Configure(rule => rule.MessageBuilder = _ => ValidationMessages.Entity_Required_Id_Error);
        }
    }
}
