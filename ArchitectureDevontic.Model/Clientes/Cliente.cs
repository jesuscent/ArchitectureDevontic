using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureDevontic.Model.Clientes
{
    public class Cliente
    {
        [Key]       
        public int CLienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
