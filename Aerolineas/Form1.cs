using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL;

namespace Aerolineas
{
    public partial class Form1 : Form
    {
        private Class1 odjOper = new Class1();
        private Conection objConnection = new Conection();
        
        private object cbxAerolinea;
        private int id = 0;


        public Form1()
        {
            InitializeComponent();
        }

        public void MontoDestino(String Destino)
        {
            try
            {

                switch (Destino)
                {
                    case "Argentina":
                        this.txtPTiquete.Text = "200";

                        break;
                    case "Bolivia":
                        this.txtPTiquete.Text = "250";
                        break;
                    case "Brasil":
                        this.txtPTiquete.Text = "325";
                        break;
                    case "Chile":
                        this.txtPTiquete.Text = "275";
                        break;
                    case "Colombia":
                        this.txtPTiquete.Text = "205";
                        break;
                    case "Ecuador":
                        this.txtPTiquete.Text = "230";
                        break;
                    case "Guyana":
                        this.txtPTiquete.Text = "270";
                        break;
                    case "Nicaragua":
                        this.txtPTiquete.Text = "120";
                        break;

                }
            }
            catch (Exception error)
            {
                       
            }
        }

        private void cbxDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.MontoDestino(this.cbxDestino.SelectedItem.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Escoja un Destino", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MontoAerolinea(String Aerolinea)
        {
            try
            {

                switch (Aerolinea)
                { 
                    case "Avianca 24%":
                        
                        this.odjOper.PrecioTiquete = double.Parse(this.txtPTiquete.Text);
                        this.odjOper.PrecioServicio =  this.odjOper.CalcularServicio(0.24);
                        this.txtPServicio.Text = this.odjOper.PrecioServicio.ToString();
            
                        break;

                    case "Despegar 18%":
                        this.odjOper.PrecioTiquete = double.Parse(this.txtPTiquete.Text);
                        this.odjOper.PrecioServicio = this.odjOper.CalcularServicio(0.18);
                        this.txtPServicio.Text = this.odjOper.PrecioServicio.ToString();
                        break;
                    case "American Airlines 32%":
                        this.odjOper.PrecioTiquete = double.Parse(this.txtPTiquete.Text);
                        this.odjOper.PrecioServicio = this.odjOper.CalcularServicio(0.32);
                        this.txtPServicio.Text = this.odjOper.PrecioServicio.ToString();
                        break;
                    case "Japan Airlines 25%":
                        this.odjOper.PrecioTiquete = double.Parse(this.txtPTiquete.Text);
                        this.odjOper.PrecioServicio = this.odjOper.CalcularServicio(0.25);
                        this.txtPServicio.Text = this.odjOper.PrecioServicio.ToString();
                        break;
                    case "Qatar Airways 27%":
                        this.odjOper.PrecioTiquete = double.Parse(this.txtPTiquete.Text);
                        this.odjOper.PrecioServicio = this.odjOper.CalcularServicio(0.27);
                        this.txtPServicio.Text = this.odjOper.PrecioServicio.ToString();
                        break;
                    

                }
            }
            catch (Exception error)
            {

            }
        }
        private void cbxAerolineas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.MontoAerolinea(this.cbxAerolineas.SelectedItem.ToString());
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Escoja una Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarPantalla() //La firma de aclaacion
        {
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtPTiquete.Text = "0";
            this.txtPServicio.Text = "0";
            this.cbxDestino.Text = " ";
            this.cbxAerolineas.Text = " ";
            this.txtPFinal.Text = "0";
            this.txtIva.Text = "0";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {


                this.odjOper.IVA = this.odjOper.CalcularIVA();
                this.txtIva.Text = this.odjOper.IVA.ToString();

                this.odjOper.PrecioFinal= this.odjOper.CalcularPrecioFinal();
                this.txtPFinal.Text= this.odjOper.PrecioFinal.ToString();
                    



            }catch(Exception error)
            {
                MessageBox.Show(error.Message, "Calculo Erronio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarInfo()
        {
            this.odjOper.nuevoCliente(this.txtCedula.Text, this.txtNombre.Text);
            Cliente cliente = this.odjOper.getClienteName();
            MessageBox.Show("\n"+"Nombre: "+ cliente.Cedula + "\n\n"+ "Cedula: " + cliente.NombreCompleto + "\n\n"+"Precio Final: "+ this.odjOper.PrecioFinal,"\n"+ "Facturacion del Viaje");
        }
        private void InsertDataUser()
        {
            this.odjOper.nuevoCliente(this.txtCedula.Text, this.txtNombre.Text);
            Cliente cliente = this.odjOper.getClienteName();
            bool exitoso = this.objConnection.insertDataClient(cliente);

            if (exitoso)
            {
                Console.WriteLine("Usuario  guardado exitosamente");
            }
            else
            {
                Console.WriteLine("algo salio mal insertando usuario");
            }

        }
        private void InserDataticket()
        {
            try
            {
                this.odjOper.nuevoCliente(this.txtCedula.Text, this.txtNombre.Text);
                Cliente cliente = this.odjOper.getClienteName();
                DateTime date = DateTime.Today;
                             
                string destino = this.cbxDestino.SelectedItem.ToString();
                
                string aerolinea = this.cbxAerolineas.SelectedItem.ToString();
                //aqui empiezan los floats de cada monto que ocupamos saber del tiquete;
                
                int PrecioTiquete = Decimal.ToInt32(decimal.Parse(this.txtPTiquete.Text));
                int PrecioServicio = Decimal.ToInt32(decimal.Parse(this.txtPServicio.Text));
                int PrecioIVA = Decimal.ToInt32(decimal.Parse(this.txtIva.Text));
                int PrecioFinal = Decimal.ToInt32(decimal.Parse(this.txtPFinal.Text));

                

                //funcion para meter el ticket y sus datos a la base de datos
               bool exitoso = this.objConnection.inserDataTicket(cliente.Cedula,destino,aerolinea,PrecioTiquete,PrecioServicio,PrecioIVA,PrecioFinal); ;
                // incrementamos el id automaticamente cada vez que se presione el boton de pagar
              
                if (exitoso)
                {
                    MessageBox.Show("Tiquete y usuario procesados correctamente", "Informacion", MessageBoxButtons.OK);
                }
                else {
                    MessageBox.Show("Informacion", "Tiquete no se pudo procesar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch ( Exception ex)
            {

                throw ex;
            }
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
               

               
                if (this.txtNombre.Text != "" && this.txtCedula.Text != "")
                {


                    // TODO: EJECUTAR LOS METODOS AQUI DE DAL 
                    // inserDataticket or InserDataUser both
                    this.InsertDataUser();

                    //insertar datos de tiquete
                    this.InserDataticket();


                    MostrarInfo();


                }


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Informacion Erronea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}





    
    