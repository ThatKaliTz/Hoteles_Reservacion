using PIA___MAD.SQL_Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___MAD;

namespace PIA___MAD.Pantallas_Operativo
{

    public partial class btnRegistrarCliente : Form
    {
        string usuario;
        public btnRegistrarCliente()
        {
            InitializeComponent();
        }

        private void clientes_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegCliente_Click(object sender, EventArgs e)
        {
            ConexionSQL conexionSQL = new ConexionSQL();
            Admin admin = new Admin();
            usuario = Validaciones.usuario;
            
            try
            {
                string Nombre = Convert.ToString(txtNombre.Text);
                string ApellidoP = Convert.ToString(txtApellidoP.Text);
                string ApellidoM = Convert.ToString(txtApellidoM.Text);
                string Correo = Convert.ToString(txtCorreo.Text);
                string RFC = Convert.ToString(txtRFC.Text);
                DateTime Nacimiento = dtpNacimiento.Value;
                string EstadoCivil = cbEstadoCivil.SelectedItem.ToString();
                string Referencia = Convert.ToString(txtReferencia.Text);
                string Calle = Convert.ToString(txtCalle.Text);
                string Colonia = Convert.ToString(txtColonia.Text);
                string Municipio = Convert.ToString(txtMunicipio.Text);
                string Estado = Convert.ToString(txtEstado.Text);
                string Telefono = Convert.ToString(txtTelefono.Text);

               
                conexionSQL.registarCliente(RFC, Nombre, ApellidoP, ApellidoM, Correo, Referencia, 
                    EstadoCivil, Calle, Colonia, Municipio, Estado, Telefono, Nacimiento);

                MessageBox.Show("Registro completado", "Yay", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtRFC.Clear();
                txtNombre.Clear();
                txtApellidoP.Clear();
                txtApellidoM.Clear();
                txtCorreo.Clear();
                txtReferencia.Clear();
                txtCalle.Clear();
                txtReferencia.Clear();
                txtColonia.Clear();
                txtMunicipio.Clear();
                txtEstado.Clear();
                txtTelefono.Clear();
                cbEstadoCivil.SelectedIndex = -1;
                dtpNacimiento.ResetText();
            }
            catch 
            {

                
            }

        }
    }
}
