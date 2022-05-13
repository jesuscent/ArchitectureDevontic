using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Dtos
{
    public class PedidoResponse
    {
        public int PedidoId { get; set; }
        public int CLienteId { get; set; }
        public ClienteResponse Cliente { get; set; }
        public List<PedidoItemResponse> PedidoItems { get; set; }
        public DateTime Date { get; set; }
    }
}
