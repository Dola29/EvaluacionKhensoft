using Microsoft.EntityFrameworkCore;
using PruebaKhensoft.Interfaces;
using PruebaKhensoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaKhensoft.Data.Repos
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly ApplicationDBContext _context;

        public PermissionTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PermissionType> CreatePermissionTypeAsync(PermissionType permissionType)
        {
            _context.PermissionTypes.Add(permissionType);
            await _context.SaveChangesAsync();
            return permissionType;
        }
        public async Task<PermissionType> DeletePermissionTypeAsync(PermissionType permission)
        {
            _context.PermissionTypes.Remove(permission);
            await _context.SaveChangesAsync();
            return permission;
        }
        public async Task<List<PermissionType>> GetAllPermissionsTypeAsync()
        {
            return await _context.PermissionTypes.ToListAsync();
        }
        public async Task<PermissionType> GetByIdAsync(int id)
        {
            return await _context.PermissionTypes.FirstOrDefaultAsync(permissionType => permissionType.Id == id);
        }
        public async Task<PermissionType> UpdatePermissionTypeAsync(PermissionType permissionType)
        {
            _context.PermissionTypes.Update(permissionType);
            await _context.SaveChangesAsync();
            return permissionType;
        }

    }
}
