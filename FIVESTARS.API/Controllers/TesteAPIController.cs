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
    [Route("api/Teste")]
    [ApiController]
    public class TesteAPIController : BaseController
    {
        private readonly TesteHandler _handler;

        public TesteAPIController(TesteHandler handler) : base(handler)
        {
            _handler = handler;
        }

        [HttpGet("Buscar")]
        public IActionResult Get()
        {
            return Response(_handler.Handler());
        }
    }
}
