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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Tests.Validation
{
    public class TagValidationTests
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
        public async Task AddTag_IfInvalidDescription_MustReturnErrorResponse()
        {
            //Arrange
            CreateTagCommandRequest request = new CreateTagCommandRequest("test", "");

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Tag_Description_Length_Error);
        }

        [Test]
        public async Task AddTag_IfInvalidName_MustReturnErrorResponse()
        {
            //Arrange
            CreateTagCommandRequest request = new CreateTagCommandRequest("", "test");

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Tag_Name_Length_Error);
        }

        [Test]
        public async Task DeleteTag_IfInvalidId_MustReturnErrorResponse()
        {
            //Arrange
            DeleteTagCommandRequest request = new DeleteTagCommandRequest();

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Entity_Required_Id_Error);
        }

        [Test]
        public async Task UpdateTag_IfInvalidId_MustReturnErrorResponse()
        {
            //Arrange
            UpdateTagCommandRequest request = new UpdateTagCommandRequest { Name = "test", Description = "test" };

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Entity_Required_Id_Error);
        }

        [Test]
        public async Task UpdateTag_IfInvalidName_MustReturnErrorResponse()
        {
            //Arrange
            UpdateTagCommandRequest request = new UpdateTagCommandRequest
            {
                Id = 1,
                Description = "test",
            };

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Tag_Name_Length_Error);
        }

        [Test]
        public async Task UpdateNote_IfInvalidDescription_MustReturnErrorResponse()
        {
            //Arrange
            UpdateTagCommandRequest request = new UpdateTagCommandRequest
            {
                Id = 1,
                Name = "test",
            };

            //Act
            var result = await mediator.Send(request);

            //Assert
            result.Should().BeAssignableTo(typeof(AppResponse));
            result.IsSucceed.Should().BeFalse();
            result.Message.Should().BeSameAs(ValidationMessages.Tag_Description_Length_Error);
        }
    }
}
