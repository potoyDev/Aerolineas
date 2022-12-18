using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Tiquete
    {


        public decimal PrecioTiquete { get; set; }

        public decimal IVA { get; set; }
        public decimal PrecioServicio { get; set; }
        public decimal PrecioFinal { get; set; }


        private Cliente objcliente = new Cliente();
        public void nuevoCliente(string cedula, string nombre)
        {
            this.objcliente.nuevoCliente(cedula, nombre);
        }
        public Cliente getClienteName()
        {
            return this.objcliente.getCliente();
        }


        public decimal CalcularServicio(decimal Tarifa)
        {
            return this.PrecioTiquete + (this.PrecioTiquete * Tarifa);
        }

        public decimal CalcularIVA()
        {
            return (this.PrecioServicio * decimal.Parse("0,13"));
        }

        public decimal CalcularPrecioFinal()
        {
            return this.PrecioServicio + CalcularIVA();
        }

     
     }

        
}
