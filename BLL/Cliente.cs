using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente
    {
        public string Cedula;
        public string NombreCompleto;

        public void nuevoCliente(string cedula,string nombre)
        {
            this.Cedula = cedula;
            this.NombreCompleto = nombre;

        }
        public Cliente getCliente()
        {
            return this;
        }

        
    }
}
