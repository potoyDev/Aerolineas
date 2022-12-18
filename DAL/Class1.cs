using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL;
using System.Globalization;

namespace DAL
{
    public class Conection
     {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private SqlDataAdapter adapter;
        private DataSet ds;
        
        private string stringConexion;
        public Conection()
        {
            this.stringConexion = "data source=DESKTOP-MR95TT9\\MYSQL; initial catalog=VuelosCR; user id=AppTiquetes; password=UH2022$;";
        }

        // se le pasa el id que ya esta incrementado automaticamente 
        public bool inserDataTicket(string cedCliente, string destino, string aerolinea, int precio, int montoService, int montoIVA, int PrecioTotal)
        {
            try
            {
                this.connection = new SqlConnection(this.stringConexion);
                //se intentode abrir la conexion
                this.connection.Open();
                // esto es el commit
                //esto es otro commit jeje
                //otro cambio
                // se debe de instanciar un comando
                this.command = new SqlCommand();
                //se debe asignar la conexion
                this.command.Connection = this.connection;

                //se debe indicar el tipo de comando que se debe ejecutar
                this.command.CommandType = CommandType.Text;
                //NOTA EL ID EN LA BASE DE DATOS SE GENERA AUTOMATICAMENTE 
               
                //string montoIva = montoIVA.ToString() ;
                // montoIva = montoIva.Replace(",", ".");
                //montoIVA = int.Parse(montoIva, CultureInfo.InvariantCulture);

                string prueba1 = $"values('{cedCliente}', '{destino}', '{aerolinea}',{precio},{montoService},{montoIVA},{PrecioTotal}";

                // Los double no se ponen en '' simples porque sino serian varchar 
                this.command.CommandText = $"insert into Tiquetes(cedCliente,destino,aerolinea,precio,montoServicio,montoIva,precioTotal)values('{cedCliente}', '{destino}', '{aerolinea}',{precio},{montoService},{montoIVA},{PrecioTotal})";
                
                // this.command.ExecuteNonQuery();

                bool _inserData = false;
                if (this.command.ExecuteNonQuery() > 0)
                {
                    _inserData = true;


                }
                return _inserData;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        // SE le pasa el objeto cliente para meter los datos en la base
        public bool insertDataClient(Cliente objCliente)
        {
            try
            {
                this.connection = new SqlConnection(this.stringConexion);
                //se intentode abrir la conexion
                this.connection.Open();
                // se debe de instanciar un comando
                this.command = new SqlCommand();
                //se debe asignar la conexion
                this.command.Connection = this.connection;

                //se debe indicar el tipo de comando que se debe ejecutar
                this.command.CommandType = CommandType.Text;

                this.command.CommandText = String.Format("insert into Clientes(cedula,nombreCompleto)values('{0}','{1}')", objCliente.Cedula,objCliente.NombreCompleto);
               // this.command.ExecuteNonQuery();

                bool _inserData = false;
                if (this.command.ExecuteNonQuery() > 0 ) {
                    _inserData = true;

                    
                }
                return _inserData;
            }catch(Exception ex)
            {
                throw ex;
               
            }

        }



    }
}
