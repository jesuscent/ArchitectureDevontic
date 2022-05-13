
using ArchitectureDevontic.Model.Productos;
using ArchitectureDevontic.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Service.Iservices.Productos
{
    public interface IProductoServices
    {
        Task<List<Producto>> GetAll();
        Task<ResponseHelper> Create(Producto model);
        Task<ResponseHelper> Edit(Producto model);
        Task<ResponseHelper> Delete(int id);
        Task<Producto> GetById(int Id);
        Task<List<Producto>> GetProductoPedido();
    }
}
