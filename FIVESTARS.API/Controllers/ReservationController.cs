using FIVESTARS.Domain.Commands.Reservation.Input;
using FIVESTARS.Domain.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIVESTARS.API.Controllers
{
    [Route("api/Reservation")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class ReservationController : BaseController
    {
        private readonly ReservationHandler _handler;

        public ReservationController(ReservationHandler handler) : base(handler)
        {
            _handler = handler;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Response(_handler.Handler());
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] SaveReservationCommand command)
        {
            return Response(_handler.Handler(command));
        }

        [HttpPost("DeleteReserve")]
        public IActionResult Post([FromQuery] int idClient)
        {
            return Response(_handler.Handler(idClient));
        }

    }
}
