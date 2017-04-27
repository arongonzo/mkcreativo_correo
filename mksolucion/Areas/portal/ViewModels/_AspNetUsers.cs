using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models{
    public class _AspNetUsers
    {
        public string Id { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "E-mail Confirmado")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Password hash")]
        public string PasswordHash { get; set; }

        [Display(Name = "Security Stamp")]
        public string SecurityStamp { get; set; }

        [Display(Name = "Numero de Telefono")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Telefono Confirmado")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "Factor Dos Claves")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "Fecha de Bloqueo")]
        public DateTime? LockoutEndDateUtc { get; set; }

        [Display(Name = "Usuario Bloqueado")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "Numero de Fallos de Acceso")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }


    }
}