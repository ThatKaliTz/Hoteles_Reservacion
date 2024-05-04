﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___MAD.Pantallas;
using PIA___MAD.Pantallas_Admin;
using PIA___MAD.SQL_Conexion;

namespace PIA___MAD
{
    public partial class regTipoHab : Form
    {
        bool isRegistered = false;

        public regTipoHab()
        {
            InitializeComponent();
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void limpiarTextBox()
        {
            txtNombre.Clear();
            txtNumCamas.Clear();
            cbTipoCama.SelectedIndex = -1;
            txtPrecioNoche.Clear();
            txtCantidadPersonas.Clear();
            cbNivelHabitacion.SelectedIndex = -1;
            checkbPiscina.Checked = false;
            checkbJardin.Checked = false;
            checkbPlaya.Checked = false;

        }

        private void btnRegHabitacion_Click(object sender, EventArgs e)
        {
            // Mandar a llamar el Table Adapter
            //conexionTablasTableAdapters.UsuarioTableAdapter tableManager = new conexionTablasTableAdapters.UsuarioTableAdapter();
            var Err = false; // SI no hay error

            ConexionSQL conexion = new ConexionSQL();

            try
            {
                // Convertir los datos de los textBoxs
                string nombreTipo = Convert.ToString(txtNombre.Text);
                int numeroCamas = Convert.ToInt32(txtNumCamas.Text);
                string filtroSeleccionado = cbTipoCama.SelectedItem.ToString();
                string nivelHabitacion = cbNivelHabitacion.SelectedItem.ToString();
                float precioNoche = Convert.ToSingle(txtPrecioNoche.Text);
                int cantidadPersonas = Convert.ToInt32(txtCantidadPersonas.Text);

                // Bool
                bool bPiscina = checkbPiscina.Checked;
                bool bJardin = checkbJardin.Checked;
                bool bPlaya = checkbPlaya.Checked;
                // Bool a Int
                int amenidadPiscina = bPiscina ? 1 : 0;
                int amenidadPlaya = bJardin ? 1 : 0;
                int amenidadJardin = bPlaya ? 1 : 0;
                conexion.registrarTipoHabitacion(nombreTipo, precioNoche, cantidadPersonas, numeroCamas, filtroSeleccionado,
                 nivelHabitacion, amenidadPiscina, amenidadPlaya, amenidadJardin, Validaciones.usuario);
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
                isRegistered = true;
                MessageBox.Show("Registro completado", "Yay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarTextBox();
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbNivelHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (isRegistered)
            {
                Validaciones.inTipoHab = false;
                panelOpenForm.Visible = true;
                panelOpenForm.Controls.Clear();
                regHabitacion habitacionP = new regHabitacion();
                habitacionP.TopLevel = false;
                panelOpenForm.Controls.Add(habitacionP);
                panelOpenForm.BringToFront();
                habitacionP.Show(); 
            }
            else
                MessageBox.Show("Registre al menos un tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void regTipoHab_Load(object sender, EventArgs e)
        {
            Validaciones.inTipoHab = true;

        }
    }
}
