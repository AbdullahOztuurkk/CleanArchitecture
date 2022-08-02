using CleanArch.Domain.Common;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features
{
    public class UselessQueryRequest : IRequest<AppResponse>
    {
        public string Name { get; set; }
    }

    public class UselessValidator : AbstractValidator<UselessQueryRequest>
    {
        public UselessValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }

    public class GetAllNoteQueryHandler : IRequestHandler<UselessQueryRequest, AppResponse>
    {
        public Task<AppResponse> Handle(UselessQueryRequest request, CancellationToken cancellationToken)
        {
            //return Task.FromResult<string>($"Request value is true : {request.Name}");
            return Task.FromResult<AppResponse>(new AppResponse(true, "Hello", 200));
        }
    }
}
