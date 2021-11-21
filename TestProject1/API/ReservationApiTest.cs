using FIVESTARS.Domain.Commands.Reservation.Input;
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
    public class ReservationApiTest : IClassFixture<WebApplicationFactory<FIVESTARS.API.Startup>>
    {
        private readonly WebApplicationFactory<FIVESTARS.API.Startup> _factory;

        string urlBedroom = "api/Reservation";

        public ReservationApiTest(WebApplicationFactory<FIVESTARS.API.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/Reservation")]
        public async Task GetAllBedroomTest(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            //act
            var response = await client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [MemberData(nameof(GetNewCommand))]
        public async Task SaveReservationTest(SaveReservationCommand Bedrooms)
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
        [MemberData(nameof(GetCommandReservationBadRequest))]
        public async Task ShouldReturnBadRequestWhenCommandIsInvalid(SaveReservationCommand Bedrooms)
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

        public static IEnumerable<object[]> GetNewCommand
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                         new SaveReservationCommand() { idBedroom = 4, idClient = 9, initialDate = DateTime.Now.AddDays(30), finalDate = DateTime.Now.AddDays(31) }

                    },new object[]
                    {
                          new SaveReservationCommand() { idBedroom = 3, idClient = 10, initialDate = DateTime.Now.AddDays(35), finalDate = DateTime.Now.AddDays(37) }
                    },

                    new object[]
                    {
                         new SaveReservationCommand() {id = 1, idBedroom = 4, idClient = 9, initialDate = DateTime.Now.AddDays(1), finalDate = DateTime.Now.AddDays(5) }

                    },new object[]
                    {
                          new SaveReservationCommand() {id = 2, idBedroom = 3, idClient = 10, initialDate = DateTime.Now.AddDays(6), finalDate = DateTime.Now.AddDays(10) }
                    }

                };
            }
        }

        public static IEnumerable<object[]> GetCommandReservationBadRequest
        {
            get
            {
                return new[]
                {
                    //initial date bigger than final
                    new object[]
                    {
                        new SaveReservationCommand() { idBedroom = 4, idClient = 9, initialDate = DateTime.Now.AddDays(10), finalDate = DateTime.Now.AddDays(7) }
                    },
                    //final date unless than today
                    new object[]
                    {
                        new SaveReservationCommand() { idBedroom = 3, idClient = 10, initialDate = DateTime.Now.AddDays(11), finalDate = DateTime.Now.AddDays(-1) }
                    },
                    //initial date unless than today
                    new object[]
                    {
                        new SaveReservationCommand() {idBedroom = 9, idClient = 1, initialDate = DateTime.Now.AddDays(-1), finalDate = DateTime.Now.AddDays(7) }
                    },
                    //Client not exists
                    new object[]
                    {
                        new SaveReservationCommand() {idBedroom = 10, idClient = 200, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(8) }
                    },
                    //Bedroom not exists
                    new object[]
                    {
                        new SaveReservationCommand() {idBedroom = 200, idClient = 1, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(7) }
                    },
                    //Update
                    new object[]
                    {
                        new SaveReservationCommand() {id = 1, idBedroom = 200, idClient = 200, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(-1) }
                    },
                    //Update not exists
                    new object[]
                    {
                        new SaveReservationCommand() {id= 2, idBedroom = 200, idClient = 200, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(-1) }
                    }

                };
            }
        }

    }
}
