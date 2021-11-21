using FIVESTARS.Domain.Commands.Client;
using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Handlers;
using FIVESTARS.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using TestProject1.Fakes;
using Xunit;

namespace TestProject1.Handlers
{
    public class ClientHandlerTest
    {
        [Theory]
        [MemberData(nameof(GetCommandClients))]
        public void ShouldCreateNewClient(SaveClientCommand command)
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new ClientHandler(new FakeClientRepository());

            var retorno = handler.Handler(command);

            Assert.Equal(1, retorno);
            Assert.True(handler.Valid);

        }

        [Theory]
        [MemberData(nameof(GetCommandClientsBadRequest))]
        public void ShoudlReturnFalseWhenCommandIsinvalid(SaveClientCommand command)
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new ClientHandler(new FakeClientRepository());

            var retorno = handler.Handler(command);

            Assert.Equal(0, retorno);
            Assert.False(handler.Valid);

        }


        [Fact]
        public void ShouldReturnClients()
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new ClientHandler(new FakeClientRepository());

            var retorno = handler.Handler();

            Assert.Same(retorno.GetType(), new List<Client>().GetType());
            Assert.IsType(new Client().GetType(), retorno[0]);

            Assert.True(handler.Valid);
        }

        [Fact]
        public void ShouldDeleteClient()
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new ClientHandler(new FakeClientRepository());

            var retorno = handler.Handler(1);

            Assert.Equal(1, retorno);

            Assert.True(handler.Valid);
        }

        public static IEnumerable<object[]> GetCommandClients
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new SaveClientCommand() {NOME = "XUNIT", Email = "tesrrr442@GMAIL.COM", CEP = "04824090", CPF = "41079944855", birthDate = DateTime.Now}
                    },new object[]
                    {
                        new SaveClientCommand() {NOME = "XUNIT2", Email = "tesrrr44.COM", CEP = "04824090", CPF = "41079944855", birthDate = DateTime.Now}
                    },
                    new object[]
                    {
                        new SaveClientCommand() {id = 1, NOME = "XUNIT", Email = "tesrrr442@GMAIL.COM", CEP = "04824090", CPF = "41079944855", birthDate = DateTime.Now}
                    },new object[]
                    {
                        new SaveClientCommand() {id = 1, NOME = "XUNIT2", Email = "tesrrr44.COM", CEP = "04824090", CPF = "41079944855", birthDate = DateTime.Now}
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
                        new SaveClientCommand() {NOME = "XUNIT", Email = "tesrrr442@GMAIL.COM", CEP = "04725090", CPF = "0", birthDate = DateTime.Now}
                    },
                    //CEP with unless character
                    new object[]
                    {
                        new SaveClientCommand() {NOME = "XUNIT2", Email = "tesrrr44.COM", CEP = "2", CPF = "41088722010", birthDate = DateTime.Now}
                    },
                    //Nome null
                    new object[]
                    {
                        new SaveClientCommand() {id = 1, NOME = "", Email = "tesrrr442@GMAIL.COM", CEP = "04824090", CPF = "41079944855", birthDate = DateTime.Now}
                    },
                    //CPF null
                    new object[]
                    {
                        new SaveClientCommand() {id = 1, NOME = "XUNIT2", Email = "tesrrr44.COM", CEP = "04824090", CPF = "", birthDate = DateTime.Now}
                    }
                };
            }
        }



    }
}
