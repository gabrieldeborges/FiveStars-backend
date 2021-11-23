using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Infra.Repository;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace TestApi.Infra
{
    public class ClientInfraTest
    {
        private readonly IClientRepository _repository;

        public ClientInfraTest(IClientRepository teste)
        {
            _repository = teste;
        }


        [Fact]
        public async Task Test3()
        {
            // Arrange
            var factory = new WebApplicationFactory<WebApplication41.Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Home/Test");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Be("This is a test");
        }


    }
}
