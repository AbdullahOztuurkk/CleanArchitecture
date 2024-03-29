﻿using CleanArch.Application.Features.Commands.CreateEvent;
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
                .Configure(rule => rule.MessageBuilder = _ => ValidationMessages.Note_Content_Length_Error);

            RuleFor(pred => pred.Title)
                .MinimumLength(1)
                .MaximumLength(25)
                .NotEmpty()
                .Configure(rule => rule.MessageBuilder = _ => ValidationMessages.Note_Title_Length_Error);
        }
    }
}
