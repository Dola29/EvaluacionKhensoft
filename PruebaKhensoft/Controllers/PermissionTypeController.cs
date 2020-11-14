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
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeRepository _permissionType;

        public PermissionTypeController(IPermissionTypeRepository permissionType)
        {
            _permissionType = permissionType;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _permissionType.GetAllPermissionsTypeAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _permissionType.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PermissionType permissionType)
        {
            return Ok(await _permissionType.CreatePermissionTypeAsync(permissionType));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] PermissionType permissionType)
        {
            if (id != permissionType.Id)
            {
                return BadRequest();
            }

            return Ok(await _permissionType.UpdatePermissionTypeAsync(permissionType));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PermissionType permissionType)
        {
          return Ok(await _permissionType.DeletePermissionTypeAsync(permissionType));
        }

    }
}
