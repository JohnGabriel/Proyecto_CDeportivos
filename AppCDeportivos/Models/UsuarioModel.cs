using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppCDeportivos.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioID { get; set; }
        [Display(Name = "Usuario: ")]
        [Required(ErrorMessage = "El usuario es requerido")]
        public string Usuario { get; set; }
        [Display(Name = "Contraseña: ")]
        [Required(ErrorMessage = "La contraseña es requerido.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}