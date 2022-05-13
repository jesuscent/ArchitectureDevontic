using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Dtos
{
    public class PedidoItemResponse
    {
        public int PedidoItemId { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public ProductoResponse Product { get; set; }
        public int Quantity { get; set; }
    }
}
