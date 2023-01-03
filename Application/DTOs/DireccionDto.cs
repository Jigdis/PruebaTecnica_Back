using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DireccionDto
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string CalleNumero { get; set; }
        public string Colonia { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}
