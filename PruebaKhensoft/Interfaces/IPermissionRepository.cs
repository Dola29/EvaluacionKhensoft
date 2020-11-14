using PruebaKhensoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaKhensoft.Interfaces
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetByIdAsync(int id);
        Task<Permission> CreatePermissionAsync(Permission permission);
        Task<Permission> UpdatePermissionAsync(Permission permission);
        Task<Permission> DeletePermissionAsync(Permission permission);
    }
}
