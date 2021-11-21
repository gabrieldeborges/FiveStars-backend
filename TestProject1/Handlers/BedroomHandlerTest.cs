using FIVESTARS.Domain.Commands.Bedrooms.Input;
using FIVESTARS.Domain.Handlers;
using FIVESTARS.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TestProject1.Fakes;
using FIVESTARS.Domain.Entities;

namespace TestProject1.Handlers
{
    public class BedroomHandlerTest
    {
        [Theory]
        [MemberData(nameof(GetCommandNewBedroom))]
        public void ShouldUpdateCreateBedroom(SaveBedroomCommand command)
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new BedroomHandler(new FakeBedroomRepository());

            var retorno = handler.Handler(command);

            Assert.Equal(1, retorno);
            Assert.True(handler.Valid);

        }

        [Theory]
        [MemberData(nameof(GetCommandNewBedroomBadRequest))]
        public void ShouldReturnFalseWhenCommandIsNotValid(SaveBedroomCommand command)
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new BedroomHandler(new FakeBedroomRepository());

            var retorno = handler.Handler(command);

            Assert.Equal(0, retorno);
            Assert.False(handler.Valid);

        }



        [Fact]
        public void ShouldReturnBedrooms()
        {
            var repositoryFake = new Mock<IBedroomRepository>();

            var handler = new BedroomHandler(new FakeBedroomRepository());

            var retorno = handler.Handler();

            Assert.Same(retorno.GetType(), new List<Bedroom>().GetType());
            Assert.IsType(new Bedroom().GetType(), retorno[0]);

            Assert.True(handler.Valid);

        }


        [Fact]
        public void ShouldDeleteBedroom()
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new BedroomHandler(new FakeBedroomRepository());

            var retorno = handler.Handler(1);

            Assert.Equal(1, retorno);

            Assert.True(handler.Valid);
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
                        new SaveBedroomCommand() {quantityBathroom = 1, bedType = "Cama de Solteiro", door = 3, floor = 2, moreInformation = "Quarto comum 1 comodo", quantityBeds = 1}
                    },
                     new object[]
                    {
                        new SaveBedroomCommand() {id = 1, quantityBathroom = 3, bedType = "Cama de casado", door = 3, floor = 2, moreInformation = "Quarto comum para casais", quantityBeds = 2}
                    },new object[]
                    {
                        new SaveBedroomCommand() {id = 1,  quantityBathroom = 1, bedType = "Cama de Solteiro", door = 3, floor = 2, moreInformation = "Quarto comum 1 comodo", quantityBeds = 1}
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
