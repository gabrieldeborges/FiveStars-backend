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

    public class ClientApiTest : IClassFixture<WebApplicationFactory<FIVESTARS.API.Startup>>
    {
        private readonly WebApplicationFactory<FIVESTARS.API.Startup> _factory;

        public ClientApiTest(WebApplicationFactory<FIVESTARS.API.Startup> factory)
        {
            _factory = factory;
        }

        string urlClient = "api/Client";

        [Theory]
        [InlineData("api/Client")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
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
        //[InlineData("api/Client")]
        [MemberData(nameof(GetCommandNewClient))]
        public async Task Save_Clients(SaveClientCommand Clients)
        {
            // Arrange
            var jsonContent = JsonConvert.SerializeObject(Clients);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var client = _factory.CreateClient();
            // Act
            var response = await client.PostAsync(urlClient, contentString);
            // Assert

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        //[InlineData("api/Client")]
        [MemberData(nameof(GetCommandClientsBadRequest))]
        public async Task ShouldReturnBadRequestWhenCommandIsInvalid(SaveClientCommand Clients)
        {
            // Arrange
            var jsonContent = JsonConvert.SerializeObject(Clients);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var client = _factory.CreateClient();
            // Act
            var response = await client.PostAsync(urlClient, contentString);
            // Assert


            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(response.IsSuccessStatusCode);
        }


        public static IEnumerable<object[]> GetCommandNewClient
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new SaveClientCommand() {NOME = "XUNIT", Email = "gabriel@gmail.COM", CEP = "04824090", CPF = "41079944855", birthDate = DateTime.Now}
                    },new object[]
                    {
                        new SaveClientCommand() {NOME = "XUNIT", Email = "gabriel2@gmail.COM", CEP = "04824092", CPF = "41079944822", birthDate = DateTime.Now }
                    },

                     new object[]
                    {
                        new SaveClientCommand() {id = 9, NOME = "XUNIT", Email = "atualizado1@gmail.COM", CEP = "04824090", CPF = "41079944855", birthDate = DateTime.Now}

                    },new object[]
                    {
                        new SaveClientCommand() {id = 10, NOME = "XUNIT", Email = "atualizado12@gmail.COM", CEP = "04824092", CPF = "41079944822", birthDate = DateTime.Now }
                    }
                };
            }
        }

        public static IEnumerable<object[]> GetCommandClientsBadRequest
        {
            get
            {
                return new[]
                {
                    //CPF with unless character
                    new object[]
                    {
                        new SaveClientCommand() {NOME = "XUNIT", Email = "hhhhhhhh2@GMAIL.COM", CEP = "04725090", CPF = "0", birthDate = DateTime.Now}
                    },
                    //CEP with unless character
                    new object[]
                    {
                        new SaveClientCommand() {NOME = "XUNIT2", Email = "hhhhhhhh2222.COM", CEP = "2", CPF = "41088722010", birthDate = DateTime.Now}
                    },
                    //Nome null
                    new object[]
                    {
                        new SaveClientCommand() {id = 9, NOME = "", Email = "hhhhhhhh222233@GMAIL.COM", CEP = "04824090", CPF = "41079944855", birthDate = DateTime.Now}
                    },
                    //CPF null
                    new object[]
                    {
                        new SaveClientCommand() {id = 10, NOME = "XUNIT2", Email = "hhhhhhhh22223311111.COM", CEP = "04824090", CPF = "", birthDate = DateTime.Now}
                    }
                };
            }
        }


    }
}
