using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFunny.DAL
{
    public partial class Alojamiento
    {
        public string Rut { get; set; }
        public string NombreMascota { get; set; }
        public int IdTipoMascota { get; set; }
        public int IdTipoAlojamiento { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public int Dias { get; set; }

        public virtual TipoAlojamiento TipoAlojamiento { get; set; }
        public virtual TipoMascota TipoMascota { get; set; }
        public virtual Propietario Propietario { get; set; }
    }
}
