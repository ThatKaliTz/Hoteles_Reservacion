﻿using PIA___MAD.Pantallas_Admin;
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
using static PIA___MAD.Clases;

namespace PIA___MAD.Pantallas_Operativo
{
    public partial class reservaciones : Form
    {
        public Panel panelReserv
        {
            get { return panelOpenForm; }
        }

        public reservaciones()
        {
            InitializeComponent();
        }

        private void reservaciones_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
            panelOpenForm.Visible = false;
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0 
                && dataGridView2.SelectedRows.Count > 0)
            {
                // Obtener la primera fila seleccionada
                DataGridViewRow clienteSeleccionado = dataGridView1.SelectedRows[0];
                DataGridViewRow hotelSeleccionado = dataGridView2.SelectedRows[0];

                // Obtener los valores de las celdas de la fila seleccionada
                reservID.ClienteRFC = clienteSeleccionado.Cells["RFC"].Value.ToString();
                reservID.HotelID = hotelSeleccionado.Cells["idHotel"].Value.ToString();
            }


            // Aca verificamos lo que el usuario selecciono
            if (reservID.ClienteRFC != null && reservID.HotelID != null)
            {
                // Abrir otra ventana
                panelOpenForm.Visible = true;
                panelOpenForm.Controls.Clear();
                reservacionesHabitaciones reservH = new reservacionesHabitaciones();
                reservH.TopLevel = false;
                panelOpenForm.Controls.Add(reservH);
                panelOpenForm.BringToFront();
                reservH.Show();

                //MessageBox.Show(reservID.ClienteRFC + reservID.HotelID);
                //cbFiltroCliente.SelectedIndex = -1;
                //string prueba = dataGridView1.Rows[0].Cells[0].Value.ToString();
                //dtpFechaReservacion.ResetText();
                //DateTime FechaReservacion = dtpFechaReservacion.Value;
            }
            else
                MessageBox.Show("Seleccione los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            ConexionSQL conexionSQL = new ConexionSQL();

            string FiltroCliente = cbFiltroCliente.SelectedItem.ToString();
            string DatoCliente = Convert.ToString(txtDatoCliente.Text);

            if (FiltroCliente == "Apellidos") {
                DataTable dt = conexionSQL.reservaApellido(DatoCliente);
                dataGridView1.DataSource = dt;
            }

            if (FiltroCliente == "RFC")  {
                DataTable dt = conexionSQL.FiltrarClientesPorRFC(DatoCliente);
                dataGridView1.DataSource = dt;
            }

            if (FiltroCliente == "Correo")
            {
                DataTable dt = conexionSQL.FiltrarClientesPorCorreo(DatoCliente);
                dataGridView1.DataSource = dt;
            }

        }

        private void btnBuscarHotelPorCiudad_Click(object sender, EventArgs e)
        {
            ConexionSQL conexionSQL = new ConexionSQL();
            string DatoHotel = Convert.ToString(txtCiudad.Text);
            if(DatoHotel != null)
            {
                DataTable dt = conexionSQL.FiltrarHotelesReservacion(DatoHotel);
                dataGridView2.DataSource = dt;
            }
        }

    }
}
