using ArchitectureDevontic.Model.Dtos;
using ArchitectureDevontic.Model.Pedidos;
using ArchitectureDevontic.Model.Util;
using ArchitectureDevontic.Service.Iservices.Pedidos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureDevontic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoServices _pedidoServices;
        private readonly IMapper _mapper;
        public PedidosController(IPedidoServices pedidoServices, IMapper mapper)
        {
            _pedidoServices = pedidoServices;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetPedido/{PedidoId}")]
        public async Task<IActionResult> GetPedido(int PedidoId)
        {
            var response = new Pedido();
            try
            {
                response = await _pedidoServices.GetPedido(PedidoId);                
                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }
        }
        [HttpGet]
        [Route("GetPedidoByProductoId/{ProductoId}")]
        public async Task<IActionResult> GetPedidoByProductoId(int ProductoId)
        {
            var response = new List<Pedido>();
            try
            {
                response = await _pedidoServices.GetPedidoByProductoId(ProductoId);
                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PedidoRequest request)
        {
            var response = new ResponseHelper();
            try
            {
                Pedido pedido = _mapper.Map<PedidoRequest, Pedido>(request);
                response = await _pedidoServices.CreatePedido(pedido);

                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Pedido request)
        {
            var response = new ResponseHelper();
            try
            {
                //Pedido pedido = _mapper.Map<PedidoRequest, Pedido>(request);
                response = await _pedidoServices.Edit(request);

                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = new ResponseHelper();
            try
            {
                //Pedido pedido = _mapper.Map<PedidoRequest, Pedido>(request);
                response = await _pedidoServices.DeletePedido(Id);

                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }
        }

    }
}
