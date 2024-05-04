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
using System.Xml.Linq;

namespace PIA___MAD.Pantallas_Admin
{
    public partial class regHabitacion : Form
    {
        int hotelID;

        public regHabitacion()
        {
            InitializeComponent();
        }

        private void regHabitacion_Load(object sender, EventArgs e)
        {
            if (habID.HotelID != null) {
                Validaciones.inHab = true;
                ConexionSQL conexionSQL = new ConexionSQL();
                hotelID = Convert.ToInt16(habID.HotelID);
                DataTable dt = conexionSQL.ObtenerTipoHabitacionPorHotel(hotelID);
                dgvTipoHab.DataSource = dt;
            }
        }


        private void limpiarTextBox()
        {
            txtCantidad.Clear();
            txtID.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var Err = false;
            ConexionSQL conexionSQL = new ConexionSQL();
            try
            {
                int tipoHabID = Convert.ToInt16(txtID.Text);
                int cantidadHabitacion = Convert.ToInt16(txtCantidad.Text);
                bool existeValor = false;

                foreach (DataGridViewRow row in dgvTipoHab.Rows)
                {
                    int valorCelda = Convert.ToInt32(row.Cells["idTipo"].Value);

                    if (valorCelda == tipoHabID)
                    {
                        existeValor = true;
                        break;
                    }
                }

                if(!existeValor)
                {
                    MessageBox.Show("Seleccione los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Validaciones.inHab = false;

                for (int i = 0; i < cantidadHabitacion; i++)
                {
                    conexionSQL.InsertarHabitacion(tipoHabID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Err = true;
            }
            if (!Err)
            {
                MessageBox.Show("Registro completado", "Yay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarTextBox();
            }

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(!Validaciones.inHab)
            {

            }
        }
    }
}
