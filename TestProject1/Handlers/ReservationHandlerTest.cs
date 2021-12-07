using FIVESTARS.Domain.Commands.Reservation.Input;
using FIVESTARS.Domain.Commands.Reservation.Output;
using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Handlers;
using FIVESTARS.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Fakes;
using Xunit;

namespace TestProject1.Handlers
{
    public class ReservationHandlerTest
    {
        [Theory]
        [MemberData(nameof(GetCommandReservation))]
        public void ShouldCreateOrUpdateReservation(SaveReservationCommand command)
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new ReservationHandler(new FakeReserveRepository(), new FakeClientRepository(), new FakeBedroomRepository());

            var retorno = handler.Handler(command);

            Assert.Equal(1, retorno);
            Assert.True(handler.Valid);

        }

        [Theory]
        [MemberData(nameof(GetCommandReservationBadRequest))]
        public void ShouldReturnFalseWhenCommandIsNotValid(SaveReservationCommand command)
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new ReservationHandler(new FakeReserveRepository(), new FakeClientRepository(), new FakeBedroomRepository());

            var retorno = handler.Handler(command);

            Assert.Equal(0, retorno);
            Assert.False(handler.Valid);

        }

        [Fact]
        public void ShouldReturnReservations()
        {
            var repositoryFake = new Mock<IReservationRepository>();

            var handler = new ReservationHandler(new FakeReserveRepository(), new FakeClientRepository(), new FakeBedroomRepository());

            var retorno = handler.Handler();

            Assert.Same(retorno.GetType(), new List<SearchReservationsResult>().GetType());

            Assert.IsType(new SearchReservationsResult().GetType(), retorno[0]);
            Assert.True(handler.Valid);
        }



        [Fact]
        public void ShouldDeleteReservation()
        {
            var repositoryFake = new Mock<IClientRepository>();

            var handler = new ReservationHandler(new FakeReserveRepository(), new FakeClientRepository(), new FakeBedroomRepository());

            var retorno = handler.Handler(1);

            Assert.Equal(1, retorno);
            Assert.True(handler.Valid);
        }

        public static IEnumerable<object[]> GetCommandReservation
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new SaveReservationCommand() { idBedroom = 1, idClient = 1, initialDate = DateTime.Now, finalDate = DateTime.Now.AddDays(7) }
                    },new object[]
                    {
                        new SaveReservationCommand() { idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(7) }
                    },
                    new object[]
                    {
                        new SaveReservationCommand() {id = 1, idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(7) }
                    },new object[]
                    {
                        new SaveReservationCommand() {id = 2, idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(7) }
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
                        new SaveReservationCommand() { idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(10), finalDate = DateTime.Now.AddDays(7) }
                    },
                    //final date unless than today
                    new object[]
                    {
                        new SaveReservationCommand() { idBedroom = 1, idClient = 200, initialDate = DateTime.Now.AddDays(11), finalDate = DateTime.Now.AddDays(-1) }
                    },
                    //initial date unless than today
                    new object[]
                    {
                        new SaveReservationCommand() {idBedroom = 1, idClient = 1, initialDate = DateTime.Now.AddDays(-1), finalDate = DateTime.Now.AddDays(7) }
                    },
                    //Client not exists
                    new object[]
                    {
                        new SaveReservationCommand() {idBedroom = 1, idClient = 200, initialDate = DateTime.Now.AddDays(5), finalDate = DateTime.Now.AddDays(8) }
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
