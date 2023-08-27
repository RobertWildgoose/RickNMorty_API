using FluentAssertions;
using Moq;
using RickNMorty_API_Tests.Models;
using RickNMorty_API_Wrapper.Services.Implementations;
using RickNMorty_API_Wrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Tests.Services
{
    public class BaseService_Tests
    {
        private BaseService SubjectUnderTest { get; set; }
        private Mock<IRequestService> RequestServiceMock { get; set; }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetItem_WhenUrlIsInvalid_ShouldReturnNull(string url)
        {
            RequestServiceMock = new Mock<IRequestService>();
            RequestServiceMock.Setup(A => A.Get("")).ReturnsAsync("");
            SubjectUnderTest = new BaseService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.Get(url);
            response.Should().Be(string.Empty);
        }

        [Fact]
        public async Task GetItem_WhenUrlIsValid_ShouldReturnValidString()
        {
            RequestServiceMock = new Mock<IRequestService>();
            RequestServiceMock.Setup(A => A.Get("https://rickandmortyapi.com/api/base")).ReturnsAsync(@"{'FirstName': 'Test', 'LastName': 'Test'}");
            SubjectUnderTest = new BaseService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.Get("base");
            response.Should().Be(@"{'FirstName': 'Test', 'LastName': 'Test'}");
        }

        [Fact]
        public async Task ConvertItem_WhenTypeIsTestData_AndUrlIsValid_ButEndpointReturnsEmpty_ShouldReturnNull()
        {
            SubjectUnderTest = new BaseService(new Mock<IRequestService>().Object);
            var response = await SubjectUnderTest.ConvertItem<TestData>("");
            response.Should().BeNull();
        }

        [Fact]
        public async Task ConvertItem_WhenTypeIsTestData_AndUrlIsValid_ButEndpointReturnsInvalidData_ShouldReturnNull()
        {
            SubjectUnderTest = new BaseService(new Mock<IRequestService>().Object);
            var response = await SubjectUnderTest.ConvertItem<TestData>(@"{'FirstName': 'Test', 'LastName': 'Test'}");
            response.Should().NotBeNull();
            response.Id.Should().Be(0);
            response.Name.Should().BeNull();
            response.Description.Should().BeNull();
        }

        [Fact]
        public async Task ConvertItem_WhenTypeIsTestData_AndEndpointReturnsValidData_ShouldReturnValidTestData()
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new BaseService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.ConvertItem<TestData>(@"{'Name': 'Test', 'Description': 'Test', 'Id': 10}");
            response.Should().NotBeNull();
            response.Id.Should().Be(10);
            response.Name.Should().Be("Test");
            response.Description.Should().Be("Test");
        }
    }
}
