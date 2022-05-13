using ArchitectureDevontic.Model.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Pedidos
{
    public class Pedido
    {
        [Key]     
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public Cliente Clientes { get; set; }
        public List<PedidoItem> PedidoItems { get; set; }
        public DateTime Date { get; set; }
    }

    }

