using FIVESTARS.Domain.Commands.Client;
using System;
using Xunit;

namespace TestProject1.Handlers.Commands
{
    public class ClientCommandTest
    {
        [Fact]
        public void ShouldReturnFalseWhenCPFIsNotValid()
        {
            var command = new SaveClientCommand() { NOME = "Gabriel", CEP = "04824090", CPF = "277", birthDate = DateTime.Now.AddYears(-5), Email = "gabriel@gmail.com" };
            //Assert
            Assert.False(command.isvalid());

        }
        [Fact]
        public void ShouldReturnFalseWhenCEPIsNotValid()
        {
            var command = new SaveClientCommand() { NOME = "Gabriel", CEP = "221", CPF = "277", birthDate = DateTime.Now.AddYears(-5), Email = "gabriel@gmail.com" };
            //Assert
            Assert.False(command.isvalid());

        }

        [Fact]
        public void ShouldReturnTrueWhenClientIsValid()
        {
            var command = new SaveClientCommand() { NOME = "Gabriel", CEP = "04824092", CPF = "41079944712", birthDate = DateTime.Now.AddYears(-5), Email = "gabriel@gmail.com" };
            //Assert
            Assert.True(command.isvalid());

        }

        [Fact]
        public void ShouldReturnFalseWhenNomeIsNotValid()
        {
            var command = new SaveClientCommand() { NOME = "", CEP = "04814-000", CPF = "410778587-18", birthDate = DateTime.Now.AddYears(-5), Email = "gabriel@gmail.com" };
            //Assert
            Assert.False(command.isvalid());

        }


    }
}
