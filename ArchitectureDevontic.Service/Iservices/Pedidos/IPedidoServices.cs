using ArchitectureDevontic.Model.Pedidos;
using ArchitectureDevontic.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Service.Iservices.Pedidos
{
    public interface IPedidoServices
    {
        Task<ResponseHelper> CreatePedido(Pedido pedido);
        Task<Pedido> GetPedido(int PedidoId);
        Task<ResponseHelper> DeletePedido(int PedidoId);
        Task<ResponseHelper> Edit(Pedido pedido);
        Task<List<Pedido>> GetPedidoByProductoId(int Id);
    }
}
