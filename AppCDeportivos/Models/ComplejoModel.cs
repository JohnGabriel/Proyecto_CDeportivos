using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppCDeportivos.Models
{
    public class ComplejoModel
    {
        public int ComplejoID { get; set; }
        public string NombreComplejo { get; set; }
        public int TipoComplejoID { get; set; }
        public string Localizacion { get; set; }
        public int AreaTotal { get; set; }
        public string SedeID { get; set; }  

        public string NombreTipo { get; set; }
        public string NombreSede { get; set; }
        public string JefeOrganiza { get; set; }

        public virtual TipoComplejoModel TipoComplejoModel { get; set; }

    }
}