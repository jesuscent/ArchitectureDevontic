using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Dtos
{
    public class PedidoRequest
    {
        public int ClienteId { get; set; }
        public List<PedidoItemRequest> PedidoItems { get; set; }
        public DateTime Date { get; set; }
    }
}
