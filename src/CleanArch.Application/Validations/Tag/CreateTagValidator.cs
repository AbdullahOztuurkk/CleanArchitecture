using CleanArch.Application.Commands.Tag.CreateTag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
