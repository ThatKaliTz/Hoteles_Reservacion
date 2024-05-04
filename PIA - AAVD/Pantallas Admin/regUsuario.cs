using PIA___MAD.Pantallas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___MAD.Pantallas_Admin;
using PIA___MAD;
using PIA___MAD.SQL_Conexion;
using System.Text.RegularExpressions;

namespace PIA___MAD
{
    public partial class regUsuario : Form
    {

        // Un INSERT a la tabla de Usuario

        public regUsuario()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);

        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void limpiarTextBox()
        {
            txtCorreo.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtApellidoP.Clear();
            txtApellidoM.Clear();
            txtNumNomina.Clear();
            dtpNacimiento.ResetText();
            txtCalle.Clear();
            txtColonia.Clear();
            txtMunicipio.Clear();
            txtEstado.Clear();
            txtTelefono.Clear();
        }


        public bool ValidarContrasenia(string contrasenia)
        {
            // Validar longitud mínima de 8 caracteres
            if (contrasenia.Length < 8)
                return false;

            // Validar presencia de una mayúscula
            if (!Regex.IsMatch(contrasenia, "[A-Z]"))
                return false;

            // Validar presencia de una minúscula
            if (!Regex.IsMatch(contrasenia, "[a-z]"))
                return false;

            // Validar presencia de un carácter especial
            if (!Regex.IsMatch(contrasenia, @"[^a-zA-Z0-9]"))
                return false;

            // La contraseña cumple todos los criterios
            return true;
        }

        private void btnRegUsuario_Click(object sender, EventArgs e)
        {
            // Validar contra
            string Contrasenia = Convert.ToString(txtPassword.Text);
            if(!ValidarContrasenia(Contrasenia))
            {
                MessageBox.Show("Inserte una contrasenia valida. Debe de tener al menos 8 caracteres y debe de incluir una mayúscula, una minúscula y un caracter especial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ConexionSQL conexionSQL = new ConexionSQL();
            var Err = false; // SI no hay error

            try
            {
                // Convertir los datos de los textBoxs
                string correoElec = Convert.ToString(txtCorreo.Text);
                string apPat = Convert.ToString(txtApellidoP.Text);
                string apMat =Convert.ToString(txtApellidoM.Text);
                string Nombre = Convert.ToString(txtName.Text);
                int numNomina = Convert.ToInt32(txtNumNomina.Text);
                string Calle = Convert.ToString(txtCalle.Text);
                string Colonia = Convert.ToString(txtColonia.Text);
                string Municipio = Convert.ToString(txtMunicipio.Text);
                string Estado = Convert.ToString(txtEstado.Text);
                string Telefono = Convert.ToString(txtTelefono.Text);
                conexionSQL.registrarUsuario(correoElec, Nombre, apPat, apMat,
                    Contrasenia, Calle, Colonia, Municipio, Estado, Telefono, dtpNacimiento.Value.Date, numNomina);
                // Enviar los datos a la base de datos mediante el Table Adapter
                
                //tableManager.Insert(correoElec, Nombre, Contrasenia, Domicilio, Telefono, numNomina);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Err = true;
            }

            if(!Err) {
                MessageBox.Show("Datos enviados", "Yay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limpiarTextBox();

        }

        private void regUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
