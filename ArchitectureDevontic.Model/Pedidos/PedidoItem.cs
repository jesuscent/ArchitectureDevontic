using ArchitectureDevontic.Model.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Pedidos
{
    public class PedidoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoItemId { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }

        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }
        public int Quantity { get; set; }
    }
}
