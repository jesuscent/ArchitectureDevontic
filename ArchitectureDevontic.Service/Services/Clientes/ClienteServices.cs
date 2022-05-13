using ArchitectureDevontic.Database.Context;
using ArchitectureDevontic.Model.Clientes;
using ArchitectureDevontic.Model.Util;
using ArchitectureDevontic.Repository.Clientes;
using ArchitectureDevontic.Service.Iservices.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Service.Services.Clientes
{
    public class ClienteServices: IClienteServices
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteServices(MyContext context)
        {
            _clienteRepository = new ClienteRepository(context);
        }

        public async Task<ResponseHelper> Create(Cliente model)
        {
            var response = new ResponseHelper();
            try
            {
                if(await _clienteRepository.Create(model) > 0)
                {
                    response.Success = true;
                    response.Message = "Creado con éxito";
                }
            }
            catch (Exception)
            {

                response.Success = false;
                response.Message = "Error verifique su datos";
            }
            return response;
        }

        public async Task<Cliente> GetClienteById(int CLienteId) => await _clienteRepository.GetClienteById(CLienteId);
        

        public async Task<List<Cliente>> GetListCLientes() => await _clienteRepository.GetListCLientes();
        
    }
}
