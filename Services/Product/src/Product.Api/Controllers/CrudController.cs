﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICrudService<T, TSearch, TInsert, TUpdate> _service = null;
        public CrudController(ICrudService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TInsert request)
        {
            var response = await _service.InsertAsync(request);
            if (response == null)
            {
                return BadRequest();
            }

            PathString path = HttpContext.Request.Path;
            return Created(path, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TUpdate request)
        {
            var response = await _service.UpdateAsync(id, request);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.DeleteAsync(id);

            if (response == false)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
