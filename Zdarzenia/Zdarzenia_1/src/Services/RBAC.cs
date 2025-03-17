using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdarzenia_1.src.Enums;
using Zdarzenia_1.src.Models;

namespace Zdarzenia_1.src.Services {
    // RBAC - Role-Based Access Control
    public class RBAC {
        private readonly Dictionary<Role, List<Permission>> rolePermissions;

        public RBAC() {
            rolePermissions = new Dictionary<Role, List<Permission>>() {
                    {Role.Administrator, new List<Permission>{Permission.Read, Permission.Write, Permission.Delete, Permission.ManageUsers} },
                    {Role.Manager, new List<Permission>{ Permission.Read, Permission.Write } },
                    {Role.User, new List<Permission>{ Permission.Read } }
                };
        }
        public bool HasPermission(User user, Permission permission) {
            foreach (var role in user.Roles) {
                if (rolePermissions.ContainsKey(role) && rolePermissions[role].Contains(permission)) {
                    return true;
                }
            }
            return false;
        }
    }
}
