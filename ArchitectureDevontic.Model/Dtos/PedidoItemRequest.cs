using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Dtos
{
    public class PedidoItemRequest
    {
        public int ProductoId { get; set; }
        public int Quantity { get; set; }
    }
}
