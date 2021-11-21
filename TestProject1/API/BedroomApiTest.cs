using FIVESTARS.Domain.Commands.Bedrooms.Input;
using FIVESTARS.Domain.Commands.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1.API
{
    public class BedroomApiTest : IClassFixture<WebApplicationFactory<FIVESTARS.API.Startup>>
    {
        private readonly WebApplicationFactory<FIVESTARS.API.Startup> _factory;

        string urlBedroom = "api/Bedroom";

        public BedroomApiTest(WebApplicationFactory<FIVESTARS.API.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllBedroomTest()
        {

            var client = _factory.CreateClient();

            var response = await client.GetAsync(urlBedroom);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Theory]
        [MemberData(nameof(GetCommandNewBedroom))]
        public async Task SaveBedroomTest(SaveBedroomCommand Bedrooms)
        {
            // Arrange
            var jsonContent = JsonConvert.SerializeObject(Bedrooms);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var client = _factory.CreateClient();
            // Act
            var response = await client.PostAsync(urlBedroom, contentString);
            // Assert

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [MemberData(nameof(GetCommandNewBedroomBadRequest))]
        public async Task ShoudlReturnBadRequestWhenCommandIsInvalid(SaveBedroomCommand Bedrooms)
        {
            // Arrange
            var jsonContent = JsonConvert.SerializeObject(Bedrooms);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var client = _factory.CreateClient();
            // Act
            var response = await client.PostAsync(urlBedroom, contentString);
            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(response.IsSuccessStatusCode);
        }




        public static IEnumerable<object[]> GetCommandNewBedroom
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new SaveBedroomCommand() {quantityBathroom = 3, bedType = "Cama de casado", door = 3, floor = 2, moreInformation = "Quarto comum para casais", quantityBeds = 2}
                    },new object[]
                    {
                        new SaveBedroomCommand() {quantityBathroom = 4, bedType = "Cama de Solteiro", door = 3, floor = 2, moreInformation = "Quarto comum 1 comodo", quantityBeds = 1}
                    },
                     new object[]
                    {
                        new SaveBedroomCommand() {id = 3, quantityBathroom = 3, bedType = "Cama de casado", door = 3, floor = 2, moreInformation = "Quarto comum para atualizado", quantityBeds = 2}
                    },new object[]
                    {
                        new SaveBedroomCommand() {id = 4, quantityBathroom = 4, bedType = "Cama de Solteiro", door = 3, floor = 2, moreInformation = "Quarto comum 1 atualizado", quantityBeds = 1}
                    }
                };
            }
        }
        public static IEnumerable<object[]> GetCommandNewBedroomBadRequest
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new SaveBedroomCommand() {quantityBathroom = 1, bedType = "Cama de casado", door = 3, floor = 2, moreInformation = "Quarto comum para casais", quantityBeds = -2}
                    }
                };
            }
        }

    }
}
