using HexahedronIntersectionAPI.ApplicationServices;
using HexahedronIntersectionAPI.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexahedronIntersectionAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class HexahedronController : ControllerBase
    {
        private readonly HexahedronServices _hexahedronIntersectionServices;
        private readonly ILogger<HexahedronController> _logger;

        public HexahedronController(HexahedronServices hexahedronIntersectionServices, ILogger<HexahedronController> logger)
        {
            _logger = logger;
            _hexahedronIntersectionServices = hexahedronIntersectionServices;
        }

        /// <summary>
        /// Returns intersection hexahedron between two hexahedrons if exists. Else, returns null.
        /// </summary>
        /// <param name="hexahedronOneId">First hexahedron Id</param>
        /// <param name="hexahedronTwoId">Second hexahedron Id</param>
        /// <param name="hexahedronIntersectionId">Intersection hexahedron Id</param>
        [HttpGet]
        [Route("GetIntersection")]
        public async Task<IActionResult> GetIntersection(Guid hexahedronOneId, Guid hexahedronTwoId, Guid hexahedronIntersectionId)
        {
            var response = await _hexahedronIntersectionServices.GetIntersection(hexahedronOneId, hexahedronTwoId, hexahedronIntersectionId);

            if (response == null)
                _logger.LogInformation("There is not intersection");
            else
                _logger.LogInformation("Intersection returned");

            return Ok(response);
        }

        /// <summary>
        /// Gets an hexahedron by Id
        /// </summary>
        /// <param name="id">Hexahedron Id</param>
        /// <returns>Hexahedron identified by hexahedron Id</returns>
        [HttpGet]
        [Route("GetHexahedron/{id}")]
        public async Task<IActionResult> GetHexahedron(Guid id)
        {
            var response = await _hexahedronIntersectionServices.GetHexahedron(id);
            _logger.LogInformation("Hexahedron returned");
            return Ok(response);
        }

        /// <summary>
        /// Executes a command to create an hexahedron
        /// </summary>
        /// <param name="createHexahedronCommand">Create command</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddHexahedron")]
        public async Task<IActionResult>AddHexahedron(CreateHexahedronCommand createHexahedronCommand)
        {
            if (await _hexahedronIntersectionServices.HandlerCommand(createHexahedronCommand))
            {
                _logger.LogInformation("Hexahedron added");
                return Ok();
            }
            else
            {
                _logger.LogInformation("Hexahedron adding error");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Executes a command to remove an hexahedron
        /// </summary>
        /// <param name="removeHexahedronCommand">Remove command</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("RemoveHexahedron")]
        public async Task<IActionResult> RemoveHexahedron(RemoveHexahedronCommand removeHexahedronCommand)
        {
            await _hexahedronIntersectionServices.HandlerCommand(removeHexahedronCommand);
            _logger.LogInformation("Hexahedron removed");
            return Ok();
        }
    }
}
