using FIVESTARS.Domain.Commands.Reservation.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1.Handlers.Commands
{
    public class SaveReservationCommandTest
    {
        [Fact]
        public void ShouldReturnFalseWhenBedroomIs0()
        {
            var command = new SaveReservationCommand() {idBedroom = 0, idClient = 0, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now };
            //Assert
            Assert.False(command.isvalid());

        }

        [Fact]
        public void ShouldReturnFalseWhenClientIs0()
        {
            var command = new SaveReservationCommand() { idBedroom = 0, idClient = 0, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now };
            //Assert
            Assert.False(command.isvalid());

        }

        [Fact]
        public void ShouldReturnTrueWhenCommandIsValid()
        {
            var command = new SaveReservationCommand() { idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(7) };
            //Assert
            Assert.True(command.isvalid());

        }


        [Fact]
        public void ShouldReturFalseWhenDateInitialIsSmallThenToday()
        {
            var command = new SaveReservationCommand() { idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(-2), finalDate = DateTime.Now };
            //Assert
            Assert.False(command.isvalid());

        }

        [Fact]
        public void ShouldReturFalseWhenFinalDateIsSmallThenToday()
        {
            var command = new SaveReservationCommand() { idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(-1) };
            //Assert
            Assert.False(command.isvalid());

        }

        [Fact]
        public void ShouldReturnFalseWhenFinalDateIsSmallThenInitialDate()
        {
            var command = new SaveReservationCommand() { idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(-1) };
            //Assert
            Assert.False(command.isvalid());

        }
    }
}
