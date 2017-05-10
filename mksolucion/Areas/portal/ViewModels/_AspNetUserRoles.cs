using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _AspNetUserRoles
    {
        [Key]
        public string UserId { get; set; }

        [Key]
        public string RoleId { get; set; }

        [Display(Name = "Usuario")]

        public string UserName { get; set; }

        [Display(Name = "Roles")]

        public string RolName { get; set; }
    }
}