using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Class1
    {


        public double PrecioTiquete { get; set; }

        public double IVA { get; set; }
        public double PrecioServicio { get; set; }
        public double PrecioFinal { get; set; }


        private Cliente objcliente = new Cliente();
        public void nuevoCliente(string cedula, string nombre)
        {
            this.objcliente.nuevoCliente(cedula, nombre);
        }
        public Cliente getClienteName()
        {
            return this.objcliente.getCliente();
        }


        public double CalcularServicio(double Tarifa)
        {
            return this.PrecioTiquete + (this.PrecioTiquete * Tarifa);
        }

        public double CalcularIVA()
        {
            return  (this.PrecioServicio * 0.13);
        }

        public double CalcularPrecioFinal()
        {
            return this.PrecioServicio + CalcularIVA();
        }

     
     }

        
}
