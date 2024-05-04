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
using System.Text.RegularExpressions;

namespace PIA___MAD.Pantallas_Operativo
{
    public partial class pedirContraseña : Form
    {
        public string usuario;

        public pedirContraseña()
        {
            InitializeComponent();
        }

        private void pedirContraseña_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
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


        private void btnContra_Click(object sender, EventArgs e)
        {
            ConexionSQL conexionSQL = new ConexionSQL();
            string Contra = Convert.ToString(txtContra.Text);
            if (Contra != null)
            {
                // Validar contra
                if (!ValidarContrasenia(Contra)) { 
                    MessageBox.Show("Inserte una contrasenia valida. Debe de tener al menos 8 caracteres y debe de incluir una mayúscula, una minúscula y un caracter especial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                conexionSQL.ActualizarContra(usuario, Contra);
                LogIn.nuevaContra = false;
                this.Hide();
                login login_ = new login();
                login_.ShowDialog();
            }
            else
                MessageBox.Show("Seleccione los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
