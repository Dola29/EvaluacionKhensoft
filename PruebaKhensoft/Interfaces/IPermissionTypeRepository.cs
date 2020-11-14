using PruebaKhensoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaKhensoft.Interfaces
{
    public interface IPermissionTypeRepository
    {
        Task<List<PermissionType>> GetAllPermissionsTypeAsync();
        Task<PermissionType> GetByIdAsync(int id);
        Task<PermissionType> CreatePermissionTypeAsync(PermissionType permissionType);
        Task<PermissionType> UpdatePermissionTypeAsync(PermissionType permissionType);
        Task<PermissionType> DeletePermissionTypeAsync(PermissionType permissionType);
    }
}
