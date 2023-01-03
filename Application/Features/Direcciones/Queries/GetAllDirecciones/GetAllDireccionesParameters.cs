using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Queries.GetAllDirecciones
{
    public class GetAllDireccionesParameters : RequestParameter
    {
        public string? Colonia { get; set; }
        public string? Ciudad { get; set; }
    }
}
