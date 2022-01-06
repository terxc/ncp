using Microsoft.AspNetCore.Mvc;
using Navigation.API.Entities;
using Navigation.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Navigation.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _repository;

        public MenuController(IMenuRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetMenu")]
        [ProducesResponseType(typeof(Menu), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _repository.GetMenu(id);
            return Ok(menu);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Menu), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Menu>> CreateMenu([FromBody] Menu menu)
        {
            await _repository.CreateMenu(menu);
            return CreatedAtRoute("GetMenu", new { id = menu.Id }, menu);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Menu), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Menu>> UpdateMenu([FromBody] Menu menu)
        {
            await _repository.UpdateMenu(menu);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteMenu(int id)
        {
            await _repository.DeleteMenu(id);
            return Ok();
        }
    }
}
