using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Models
{
    public class Personal
    {
        public int IdPersonal { get; set; }

        public string ApPaterno { get; set; }

        public string ApMaterno { get; set; }

        public string Nombre1 { get; set; }

        public string Nombre2 { get; set; }  
        public string NombreCompleto { get; set; }

        public string FchNac { get; set; }
        public string FchIngreso { get; set; }
    }
}
