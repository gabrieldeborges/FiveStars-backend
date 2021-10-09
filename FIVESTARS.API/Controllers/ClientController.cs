using FIVESTARS.Domain.Commands.Client;
using FIVESTARS.Domain.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIVESTARS.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/Client")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly ClientHandler _handler;

        public ClientController(ClientHandler handler) : base(handler)
        {
            _handler = handler;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Response(_handler.Handler());
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] SaveClientCommand command)
        {
            return Response(_handler.Handler(command));
        }

        [HttpPost("DeleteClient")]
        public IActionResult Post([FromQuery] int idClient)
        {
            return Response(_handler.Handler(idClient));
        }
    }
}
