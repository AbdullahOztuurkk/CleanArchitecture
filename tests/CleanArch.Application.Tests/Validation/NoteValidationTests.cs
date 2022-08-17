using CleanArch.Application.Extensions;
using CleanArch.Application.Features.Commands.CreateEvent;
using CleanArch.Application.Features.Commands.DeleteEvent;
using CleanArch.Application.Features.Commands.UpdateEvent;
using CleanArch.Domain.Common;
using CleanArch.Domain.Constants;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CleanArch.Application.Tests.Validation
{
    public class NoteValidationTests
    {
        private ServiceProvider serviceProvider;
        private IMediator mediator;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddApplicationServices();
            serviceProvider = services.BuildServiceProvider();

            //Create Instance of Services
            mediator = (IMediator)serviceProvider.GetRequiredService(typeof(IMediator));
        }

        [Test]
        public async Task AddNote_IfInvalidContent_MustReturnErrorResponse()
        {
            //Arrange
            CreateNoteCommandRequest request = new CreateNoteCommandRequest("test", "");

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Note_Content_Length_Error);
        }

        [Test]
        public async Task AddNote_IfInvalidTitle_MustReturnErrorResponse()
        {
            //Arrange
            CreateNoteCommandRequest request = new CreateNoteCommandRequest("", "test");

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Note_Title_Length_Error);
        }

        [Test]
        public async Task DeleteNote_IfInvalidId_MustReturnErrorResponse()
        {
            //Arrange
            DeleteNoteCommandRequest request = new DeleteNoteCommandRequest();

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Entity_Required_Id_Error);
        }

        [Test]
        public async Task UpdateNote_IfInvalidId_MustReturnErrorResponse()
        {
            //Arrange
            UpdateNoteCommandRequest request = new UpdateNoteCommandRequest
            {
                Content = "test",
                IsStarred = true,
                Title = "test",
            };

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Entity_Required_Id_Error);
        }

        [Test]
        public async Task UpdateNote_IfInvalidContent_MustReturnErrorResponse()
        {
            //Arrange
            UpdateNoteCommandRequest request = new UpdateNoteCommandRequest
            {
                Id = 1,
                IsStarred = true,
                Title = "test",
            };

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Note_Content_Length_Error);
        }

        [Test]
        public async Task UpdateNote_IfInvalidFavorited_MustReturnErrorResponse()
        {
            //Arrange
            UpdateNoteCommandRequest request = new UpdateNoteCommandRequest
            {
                Id = 1,
                Content = "test",
                Title = "test",
            };

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Note_IsFavorited_Error);
        }

        [Test]
        public async Task UpdateNote_IfInvalidTitle_MustReturnErrorResponse()
        {
            //Arrange
            UpdateNoteCommandRequest request = new UpdateNoteCommandRequest
            {
                Id = 1,
                Content = "test",
                IsStarred = true
            };

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Note_Title_Length_Error);
        }
    }
}