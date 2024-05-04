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
using PIA___MAD.Pantallas_Operativo;
using PIA___MAD.SQL_Conexion;

namespace PIA___MAD
{
    public partial class login : Form
    {
        public int contador = 0;
        public string usuario;
        Admin admin = new Admin();
        public login()
        {

            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            contador++;

            if (checkBox1.Checked == true)
            {
                bool estadoCheckBox = checkBox1.Checked;
                int valorEntero = estadoCheckBox ? 1 : 0;

                ConexionSQL conexionSQL = new ConexionSQL();


                if (conexionSQL.Login(txtCorreo.Text, textBox1.Text, valorEntero))
                {
                    this.Hide();
                    
                    admin.usuario = txtCorreo.Text;
                    Validaciones.usuario = txtCorreo.Text;
                    admin.ShowDialog();
                }
                else
                {
                    //this.Hide();
                    //login login_ = new login();
                    //login_.ShowDialog();
                    if (contador > 3)
                    {
                        MessageBox.Show("no eres", "!!!");
                    }
                }

            }
            else
            {
                bool estadoCheckBox = checkBox1.Checked;
                int valorEntero = estadoCheckBox ? 1 : 0;

                ConexionSQL conexionSQL = new ConexionSQL();
                if (conexionSQL.Login(txtCorreo.Text, textBox1.Text, valorEntero) && LogIn.nuevaContra)
                {
                    this.Hide();
                    pedirContraseña nuevaContra = new pedirContraseña();
                    nuevaContra.usuario = txtCorreo.Text;
                    Validaciones.usuario = txtCorreo.Text;

                    nuevaContra.ShowDialog();
                }
                else if (conexionSQL.Login(txtCorreo.Text, textBox1.Text, valorEntero))
                {
                    this.Hide();
                    Operativo operativo = new Operativo();
                    operativo.usuario = txtCorreo.Text;
                    Validaciones.usuario = txtCorreo.Text;

                    operativo.ShowDialog();

                }
                else
                {
                    //this.Hide();
                    //login login_ = new login();
                    //login_.ShowDialog();
                    if (contador > 3)
                    {
                        MessageBox.Show("no eres", "!!!");
                        conexionSQL.Deshabilitar(txtCorreo.Text, 0);

                    }

                }

            }
        }


    }
}
