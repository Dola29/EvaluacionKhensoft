using Microsoft.EntityFrameworkCore;
using PruebaKhensoft.Interfaces;
using PruebaKhensoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaKhensoft.Data.Repos
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDBContext _context;

        public PermissionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Permission> CreatePermissionAsync(Permission permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<Permission> DeletePermissionAsync(Permission permission)
        {
            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<List<Permission>> GetAllPermissionsAsync()
        {
            return await _context.Permissions.Include(x => x.PermissionType).ToListAsync();
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _context.Permissions.Include(x => x.PermissionType).FirstOrDefaultAsync(permission => permission.Id == id);
        }

        public async Task<Permission> UpdatePermissionAsync(Permission permission)
        {
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
            return permission;
        }
    }
}
