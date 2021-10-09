using FIVESTARS.Domain.Commands.Bedrooms.Input;
using FIVESTARS.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIVESTARS.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/Bedroom")]
    [ApiController]
    public class BedroomController : BaseController
    {
        private readonly BedroomHandler _handler;

        public BedroomController(BedroomHandler handler) : base(handler)
        {
            _handler = handler;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Response(_handler.Handler());
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] SaveBedroomCommand command)
        {
            return Response(_handler.Handler(command));
        }
        [HttpPost("DeleteBedroom")]
        public IActionResult Post([FromQuery] int idBedroom)
        {
            return Response(_handler.Handler(idBedroom));
        }

    }
}
