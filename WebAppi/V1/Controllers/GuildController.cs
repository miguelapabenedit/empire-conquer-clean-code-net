using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.V1.Controllers
{
    public class GuildController : BaseApiController<Guild>
    {
        private readonly IGuildService _guildService;
        public GuildController(IGuildService guildService) : base(guildService)
        {
            _guildService = guildService;
        }

        /// <summary>
        /// Get an Guild list base on a Region Id
        /// </summary>
        /// <param name="regionId">regionId</param>
        /// <returns>Entity</returns>
        [HttpGet("getByRegionId", Name = "[controller]_[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<IEnumerable<Guild>>> GetByRegionId(long regionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _guildService.GetGuildsByRegionId(regionId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
