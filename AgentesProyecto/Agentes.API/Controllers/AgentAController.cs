﻿using Microsoft.AspNetCore.Mvc;

namespace Agentes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentAController : ControllerBase
    {
        private readonly Agentes.Application.Services.AgentA.AgentAService _agentAService;

        public AgentAController(Application.Services.AgentA.AgentAService agentAService)
        {
            this._agentAService = agentAService;
        }

        [HttpPost]
        public IActionResult Funcionality1([FromBody] List<string> args)
        {
            string result = string.Empty;
            try
            {
                result = _agentAService.GetFuncionality1(args);
            }
            catch(Exception ex)
            {
                if(ex.Message == "!400")
                {
                    return BadRequest(ex.InnerException.Message);
                }
                if (ex.Message == "!500")
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Ok(result);
        }
    }
}
