using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using Prognosys.Shared.Interfaces.Repositories;
using Prognosys.Shared.DTOs;
using Prognosys.Core.Services;

namespace Prognosys.Tests.UnitTests.Services
{
    public class ClientsTests
    {
        [Fact]
        public void GetClient_Should_return_client_When_client_exists()
        {
            // Arrange
            var fakeRepository = new Mock<IClientsRepository>();
            fakeRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(new ClientDto { Id = 1, Name = "Panama" });
            var sut = new ClientsService(fakeRepository.Object);

            // Act
            var result = sut.GetClient(1);

            //Assert
            result.Name.Should().Be("Panama");
        }
    }
}
