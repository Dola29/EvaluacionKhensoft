using Microsoft.AspNetCore.Mvc;
using PruebaKhensoft.Interfaces;
using PruebaKhensoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaKhensoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permission;

        public PermissionController(IPermissionRepository permission)
        {
            _permission = permission;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _permission.GetAllPermissionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _permission.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Permission permission)
        {
            return Ok(await _permission.CreatePermissionAsync(permission));
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] Permission permission)
        {
            return Ok(await _permission.UpdatePermissionAsync(permission));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Permission permission)
        {

            return Ok(await _permission.DeletePermissionAsync(permission));
        }

    }
}
