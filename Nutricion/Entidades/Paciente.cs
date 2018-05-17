using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricion.Entidades
{
    public class Paciente
    {
        public string PrimerNombre { get; set; }
        public bool Beneficiario { get; set; }
        public Telefono Telefono { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public long NumeroDocumento { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public TipoDocumento TipoDocumento { get; set; }
    }
}
