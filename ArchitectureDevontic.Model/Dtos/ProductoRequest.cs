using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Dtos
{
    public class ProductoRequest
    {
        public string? Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
