using ArchitectureDevontic.Database.Context;
using ArchitectureDevontic.Model.Pedidos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Repository.Pedidos
{
    public class PedidosRepository
    {
        private readonly MyContext  _context;
        public PedidosRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePedido(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            return await _context.SaveChangesAsync();
        }

        public async Task<Pedido> GetPedido(int PedidoId)
        {
            var pedido = await _context.Pedidos
                .Include(c => c.Clientes)
                .Include(o => o.PedidoItems)
                .ThenInclude(p => p.Producto)
                .SingleOrDefaultAsync(s => s.PedidoId == PedidoId);
            return pedido;
        }
        public async Task<int> DeletePedido(int PedidoId)
        {
            var pedido = await _context.Pedidos.Include(o => o.PedidoItems).Where(x=>x.PedidoId==PedidoId).FirstOrDefaultAsync();
            _context.Pedidos.Remove(pedido);


            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditPedido(Pedido pedido)
        {
             _context.Pedidos.Update(pedido);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Pedido>> GetPedidoByProductoId( int Id)
        {


            var query = await (from prod in _context.Productos
                               join pedItem in _context.PedidoItems on prod.ProductoId equals pedItem.ProductoId
                               join pedido in _context.Pedidos on pedItem.PedidoId equals pedido.PedidoId
                               where prod.ProductoId == Id
                               select new Pedido
                               {
                                   PedidoId = pedido.PedidoId,
                                   ClienteId = pedido.ClienteId,
                                   Clientes=pedido.Clientes,
                                   PedidoItems=pedido.PedidoItems,
                                   Date =pedido.Date
                               }).ToListAsync();
            return query;
        }
    }
}

