using ArchitectureDevontic.Model.Clientes;
using ArchitectureDevontic.Model.Dtos;
using ArchitectureDevontic.Model.Util;
using ArchitectureDevontic.Service.Iservices.Clientes;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureDevontic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteServices _clienteServices;
        private readonly IMapper _mapper;
        public ClientesController(IClienteServices clienteServices, IMapper mapper)
        {
            _clienteServices = clienteServices;
            _mapper = mapper;   
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteServices.GetListCLientes();           
            return Ok(clientes);
        }
        [HttpGet("GetByID/{Id}")]
        public async Task<IActionResult> GetAll(int Id)
        {
            var clientes = await _clienteServices.GetClienteById(Id);            
            return Ok(clientes);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ClienteRequest request)
        {
            var response = new ResponseHelper();
            try
            {
                Cliente cliente = _mapper.Map<ClienteRequest, Cliente>(request);
                response = await _clienteServices.Create(cliente);
                if (!response.Success)
                {
                    return BadRequest(response);
                }                
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }
    }
}
