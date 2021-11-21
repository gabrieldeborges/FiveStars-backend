using FIVESTARS.Domain.Commands.Bedrooms.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1.Handlers.Commands
{
    public class SaveBedroomTests
    {
        [Fact]
        public void ShouldReturnTrueWhenBedrooomIsValid()
        {
            var command = new SaveBedroomCommand() { quantityBathroom = 3, bedType = "Cama de casado", door = 3, floor = 2, moreInformation = "Quarto comum para casais", quantityBeds = 2 };
            //Assert
            Assert.True(command.isvalid());

        }
        [Fact]
        public void ShouldReturnFalseWhenQuatityIsSmallThen0()
        {
            var command = new SaveBedroomCommand() { quantityBathroom = 3, bedType = "Cama de casado", door = 3, floor = 2, moreInformation = "Quarto comum para casais", quantityBeds = -1 };
            //Assert
            Assert.False(command.isvalid());

        }
    }
}
