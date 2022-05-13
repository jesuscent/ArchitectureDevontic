using ArchitectureDevontic.Model.Clientes;
using ArchitectureDevontic.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Service.Iservices.Clientes
{
    public interface IClienteServices
    {
        Task<ResponseHelper> Create(Cliente model);
        Task<Cliente> GetClienteById(int CLienteId);
        Task<List<Cliente>> GetListCLientes();
    }
}
