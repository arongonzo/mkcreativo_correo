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

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual AspNetRoles AspNetRoles { get; set; }
    }
}