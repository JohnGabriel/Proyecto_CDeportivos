using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppCDeportivos.Models
{
    public class SedeModel
    {
        public int SedeID { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre de sede es obligatorio")]
        [StringLength(50)]
        [Display(Name = "Sede")]
        public string NombreSede { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese solo números")]
        [Required(ErrorMessage = "El numero de complejos requerido")]
        [Display(Name = "Nro Complejos")]
        public int NumeroComplejos { get; set; }
        public decimal Presupuesto { get; set; }
    }
}