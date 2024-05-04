using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PIA___MAD.Pantallas_Admin;
using PIA___MAD.SQL_Conexion;

namespace PIA___MAD.Pantallas
{
    public partial class regHoteles : Form
    {

        // Un INSERT a la tabla de Hotel

        public regHoteles()
        {
            
            InitializeComponent();
        }

        private void limpiarTextBox()
        {
            txtNombre.Clear();
            txtCiudad.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtNumPisos.Clear();
            checkbZonaTuristic.Checked = false;
            txtServiciosAd.Clear();
            checkbFrentePlaya.Checked = false;
            txtCantPiscina.Clear();
            checkbSalonEventos.Checked = false;
            txtCalle.Clear();
            txtColonia.Clear();
            dtpInicioOp.ResetText();
        }

        private void regHoteles_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegHotel_Click(object sender, EventArgs e)
        {
            // Mandar a llamar el Table Adapter
            //conexionTablasTableAdapters.UsuarioTableAdapter tableManager = new conexionTablasTableAdapters.UsuarioTableAdapter();
            var Err = false; // SI no hay error

            try
            {
                ConexionSQL conexionSQL = new ConexionSQL();

                // Convertir los datos de los textBoxs
                string nombreHotel = Convert.ToString(txtNombre.Text);
                string ciudadHotel = Convert.ToString(txtCiudad.Text);
                string estadoHotel = Convert.ToString(txtEstado.Text);
                string paisHotel = Convert.ToString(txtPais.Text);
                int numeroPisos = Convert.ToInt16(txtNumPisos.Text);
                string serviciosAd = Convert.ToString(txtServiciosAd.Text);

                // Bool
                bool bZona = checkbZonaTuristic.Checked;
                bool bPlaya = checkbFrentePlaya.Checked;
                bool bSalonE = checkbSalonEventos.Checked;
                // Bool a Int
                int zonaTur = bZona ? 1 : 0;
                int frentePlaya = bPlaya ? 1 : 0;
                int salonEvento = bSalonE ? 1 : 0;

                int cantidadPiscinas = Convert.ToInt16(txtCantPiscina.Text);
                string calleHotel = Convert.ToString(txtServiciosAd.Text);
                string coloniaHotel = Convert.ToString(txtServiciosAd.Text);
                DateTime fechaOperacion = dtpInicioOp.Value;


                conexionSQL.registrarHotel(nombreHotel, numeroPisos, ciudadHotel, estadoHotel, paisHotel, calleHotel, coloniaHotel,
                    zonaTur, serviciosAd, frentePlaya, cantidadPiscinas, salonEvento, fechaOperacion);
                // Enviar los datos a la base de datos mediante el Table Adapter

                //tableManager.Insert(correoElec, Nombre, Contrasenia, Domicilio, Telefono, numNomina);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Err = true;
            }

            if (!Err)
            {
                //MessageBox.Show("Datos enviados", "Yay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelOpenForm.Visible = true;
                panelOpenForm.Controls.Clear();
                regTipoHab habitacionP = new regTipoHab();
                habitacionP.TopLevel = false;
                panelOpenForm.Controls.Add(habitacionP);
                panelOpenForm.BringToFront();
                habitacionP.Show();
            }

            limpiarTextBox();
        }
    }
}
