using ArchitectureDevontic.Model.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Productos
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
