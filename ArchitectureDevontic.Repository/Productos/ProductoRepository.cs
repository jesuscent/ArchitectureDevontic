using ArchitectureDevontic.Database.Context;
using ArchitectureDevontic.Model.Productos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Repository.Productos
{
    public class ProductoRepository
    {
        private readonly MyContext _context;
        public ProductoRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }
        public async Task<Producto> GetById(int Id)
        {
            return await _context.Productos.FirstOrDefaultAsync(x => x.ProductoId == Id);
        }
        public async Task<int> Create(Producto model) 
        {
            _context.Productos.Add(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Edit(Producto model)
        {
            _context.Productos.Update(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var resul = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(resul);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Producto>> GetProductoPedido()
        {
            var query = await (from prod in _context.Productos
                               join pedItem in _context.PedidoItems on prod.ProductoId equals pedItem.ProductoId
                               select new Producto
                               {
                                   ProductoId = prod.ProductoId,
                                   Nombre = prod.Nombre,
                               }).ToListAsync();
            return query;
        }
    }
}
