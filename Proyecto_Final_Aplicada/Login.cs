using Proyecto_Final_Aplicada.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_Aplicada.IU.Registros
{
    public partial class Registro_Login : Form
    {
        public Registro_Login()
        {
            InitializeComponent();
        }

        Menu M = new Menu();
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            if (ValidarSesion() == DialogResult.OK)
            {
                this.Visible = false;
                M.Show();
            }
        }

        public bool ValidarUsuario()
        {
            if (UsuariosBLL.GetListUsuario(UsuariotextBox.Text).Count() == 0)
            {
                MessageBox.Show("Usuario incorrecto o No Registrado");
                return false;
            }
            return true;
        }

        public bool ValidarContrasena()
        {
            if (UsuariosBLL.GetContrasena(ContraseñatextBox.Text).Count() == 0)
            {
                MessageBox.Show("Contraseña incorrecta");
                return false;
            }
            return true;
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(UsuariotextBox.Text) && string.IsNullOrEmpty(ContraseñatextBox.Text))
            {
                UsuarioerrorProvider.SetError(UsuariotextBox, "Ingrese El Usuario");
                ContrasenaerrorProvider.SetError(ContraseñatextBox, "Ingrese La Contraseña");
                MessageBox.Show("Debe Llenar todos los campos");
            }
            if (string.IsNullOrEmpty(UsuariotextBox.Text))
            {
                UsuarioerrorProvider.SetError(UsuariotextBox, "Ingrese Su Usuario Por Favor");
                return false;
            }
            if (string.IsNullOrEmpty(ContraseñatextBox.Text))
            {
                UsuarioerrorProvider.Clear();
                ContrasenaerrorProvider.SetError(ContraseñatextBox, "Ingrese Su Contraseña Por Favor");
                return false;
            }
            return true;
        }

        public DialogResult ValidarSesion()
        {
            if (Validar() == true && ValidarUsuario() == true && ValidarContrasena() == true)
            {
                return DialogResult.OK;
            }
            return DialogResult.Cancel;
        }

        private void MostrarContrasenacheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MostrarContrasenacheckBox.Checked == true)
            {
                if (ContraseñatextBox.PasswordChar == '*')
                {
                    ContraseñatextBox.PasswordChar = '\0';
                }
            }
            else
            {
                ContraseñatextBox.PasswordChar = '*';
            }
        }

        private void Registro_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
