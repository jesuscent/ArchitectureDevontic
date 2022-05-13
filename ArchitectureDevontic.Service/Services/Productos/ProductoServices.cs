using ArchitectureDevontic.Database.Context;

using ArchitectureDevontic.Model.Productos;
using ArchitectureDevontic.Model.Util;
using ArchitectureDevontic.Repository.Productos;
using ArchitectureDevontic.Service.Iservices;
using ArchitectureDevontic.Service.Iservices.Productos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Service.Services.Productos
{
    public class ProductoServices : IProductoServices
    {
        private readonly ProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public ProductoServices(MyContext context, IMapper mapper)
        {
            _productoRepository = new ProductoRepository(context);
            _mapper = mapper;   
        }
        public async Task<ResponseHelper> Create(Producto model)
        {
            var response = new ResponseHelper();
            try
            {               
                if ( await _productoRepository.Create(model) > 0)
                {
                    response.Success = true;
                    response.Message = "producto creado";
                    response.Data = model;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseHelper> Delete(int id)
        {
            var response = new ResponseHelper();
            try
            {
                if (await _productoRepository.Delete(id) > 0)
                {
                    response.Success = true;
                    response.Message = "producto eliminado";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseHelper> Edit(Producto model)
        {
            var response = new ResponseHelper();
            try
            {
                if (await _productoRepository.Edit(model) > 0)
                {
                    response.Success = true;
                    response.Message = "producto editado";
                    response.Data = model;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<List<Producto>> GetAll()
        {
           return await _productoRepository.GetAll();
        }

        public async Task<Producto> GetById(int Id)
        {
            return await _productoRepository.GetById(Id);
        }

        public async Task<List<Producto>> GetProductoPedido()
        {
            return await _productoRepository.GetProductoPedido();
        }
    }
}
