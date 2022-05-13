using ArchitectureDevontic.Database.Context;
using ArchitectureDevontic.Model.Clientes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Repository.Clientes
{
    public class ClienteRepository
    {

        private readonly MyContext _context;
        public ClienteRepository(MyContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Cliente model)
        {
            await _context.Clientes.AddAsync(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<Cliente> GetClienteById(int CLienteId)
        {
            return await _context.Clientes.SingleOrDefaultAsync(s => s.CLienteId == CLienteId);
        }

        public async Task<List<Cliente>> GetListCLientes()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
