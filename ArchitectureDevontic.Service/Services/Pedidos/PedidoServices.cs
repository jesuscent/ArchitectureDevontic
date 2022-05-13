using ArchitectureDevontic.Database.Context;
using ArchitectureDevontic.Model.Pedidos;
using ArchitectureDevontic.Model.Util;
using ArchitectureDevontic.Repository.Pedidos;
using ArchitectureDevontic.Service.Iservices.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Service.Services.Pedidos
{
    public class PedidoServices : IPedidoServices
    {
        private readonly PedidosRepository _pedidosRepository;
        public PedidoServices(MyContext context)
        {
            _pedidosRepository = new PedidosRepository(context);
        }
        public async Task<ResponseHelper> CreatePedido(Pedido pedido)
        {
            var response = new ResponseHelper();
            try
            {
                if(await _pedidosRepository.CreatePedido(pedido) > 0)
                {
                    response.Success = true;
                    response.Message = "creado con éxito";
                }
            }
            catch (Exception ex)
            {

                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ResponseHelper> Edit(Pedido pedido)
        {
            var response = new ResponseHelper();
            try
            {
                if (await _pedidosRepository.EditPedido(pedido) > 0)
                {
                    response.Success = true;
                    response.Message = "Editado con éxito";
                }
            }
            catch (Exception ex)
            {

                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseHelper> DeletePedido(int PedidoId)
        {
            var response = new ResponseHelper();
            try
            {
                if (await _pedidosRepository.DeletePedido(PedidoId) > 0)
                {
                    response.Success = true;
                    response.Message = "Eliminado con éxito";
                }
            }
            catch (Exception ex)
            {

                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        
        public async Task<Pedido> GetPedido(int PedidoId)
        {
            return await _pedidosRepository.GetPedido(PedidoId);
        }

        public async Task<List<Pedido>> GetPedidoByProductoId(int Id)
        {
            return await _pedidosRepository.GetPedidoByProductoId(Id);
        }
    }
}
