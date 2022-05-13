
using ArchitectureDevontic.Model.Dtos;
using ArchitectureDevontic.Model.Productos;
using ArchitectureDevontic.Model.Util;
using ArchitectureDevontic.Service.Iservices.Productos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureDevontic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoServices _productoServices;
        private readonly IMapper _mapper;
        public ProductosController(IProductoServices productoServices, IMapper mapper)
        {
            _productoServices = productoServices ?? throw new ArgumentNullException(nameof(productoServices));
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new List<Producto>();
            try
            {
                response = await _productoServices.GetAll();

                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }
        }
        /// <summary>
        /// Lista de los producto que contienen un pedido
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductoPedido")]
        public async Task<IActionResult> GetProductoPedido()
        {
            var response = new List<Producto>();
            try
            {
                response = await _productoServices.GetProductoPedido();
                List<ProductoResponse> producto = _mapper.Map<List<ProductoResponse>>(response);
                
                return Ok(producto);
            }
            catch (Exception)
            {

                return NotFound(response);
            }
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var response = new Producto();
            try
            {
                response = await _productoServices.GetById(Id);

                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ProductoRequest request)
        {
            var response = new ResponseHelper();
            try
            {
                Producto producto = _mapper.Map<ProductoRequest, Producto>(request);
                response = await _productoServices.Create(producto);

                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }

        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Producto model)
        {
            var response = new ResponseHelper();
            try
            {
                response = await _productoServices.Edit(model);

                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(response);
            }

        }
    }
}
