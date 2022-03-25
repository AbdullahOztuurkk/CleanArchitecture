using CleanArch.Application.Commands.Tag.DeleteTag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Validations.Tag
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
