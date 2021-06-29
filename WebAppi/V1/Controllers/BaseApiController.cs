using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.V1.Controllers
{
    /// <summary>
    /// Base api controller
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class BaseApiController<T> : Controller where T : class
    {
        private readonly IBaseService<T> _baseService;
        private const string TEMPORAL_USER_NAME = "user Test";
        public BaseApiController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Get an entity list
        /// </summary>
        /// <returns>List of entities.</returns>
        [HttpGet(Name = "[controller]_[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _baseService.GetAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Get an entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity</returns>
        [HttpGet("{id}", Name = "[controller]_[action]/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<T>> Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _baseService.GetAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Creates an entity
        /// </summary>
        /// <param name="value">Entity</param>
        [HttpPost(Name = "[controller]_[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Post([FromBody] T value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //get user from identityProvider
            var userName = TEMPORAL_USER_NAME;

            await _baseService.CreateAsync(value, userName).ConfigureAwait(false);

            return Ok();
        }

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Entity</param>
        [HttpPut("{id}", Name = "[controller]_[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Put(long id, [FromBody] T value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //get user from identityProvider
            var userName = TEMPORAL_USER_NAME;

            await _baseService.UpdateAsync(id, value, userName).ConfigureAwait(false);

            return Ok();
        }


        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="id">Id</param>
        [HttpDelete("{id}", Name = "[controller]_[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Delete(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _baseService.DeleteAsync(id);

            return Ok();
        }
    }
}
