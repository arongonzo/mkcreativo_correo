using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _AspNetRoles
    {
        public string Id { get; set; }

        [Display(Name = "Roles")]
        public string Name { get; set; }
    }
}