
using ArchitectureDevontic.Model.Clientes;
using ArchitectureDevontic.Model.Dtos;
using ArchitectureDevontic.Model.Pedidos;
using ArchitectureDevontic.Model.Productos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteRequest>();
            CreateMap<ClienteRequest, Cliente>();

            CreateMap<Producto, ProductoRequest>();
            CreateMap<ProductoRequest, Producto>();
            CreateMap<Producto, ProductoResponse>();
            CreateMap<ProductoResponse, Producto>();

            CreateMap<Pedido, PedidoRequest>();
            CreateMap<PedidoRequest, Pedido>();

            CreateMap<PedidoItem, PedidoItemRequest>();
            CreateMap<PedidoItemRequest, PedidoItem>();

        }
    }
}