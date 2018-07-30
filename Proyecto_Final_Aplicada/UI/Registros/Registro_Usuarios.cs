using Proyecto_Final_Aplicada.BLL;
using Proyecto_Final_Aplicada.Entidades;
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
    public partial class Registro_Usuarios : Form
    {
        public Registro_Usuarios()
        {
            InitializeComponent();
        }

        public void LlenarClase(Usuarios u)
        {
            u.Usuario = UsuariotextBox.Text;
            u.Nombre = NombretextBox.Text;
            u.Clave = ContraseñatextBox.Text;
        }

        private void LlenarUsuario(Usuarios usuario)
        {
            IdnumericUpDown.Value = usuario.UsuarioId;
            UsuariotextBox.Text = usuario.Usuario;
            NombretextBox.Text = usuario.Nombre;
            ContraseñatextBox.Text = usuario.Clave;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            UsuariotextBox.Text = string.Empty;
            NombretextBox.Text = string.Empty;
            ContraseñatextBox.Text = string.Empty;
            ConfirmartextBox.Text = string.Empty;
            NombreerrorProvider.Clear();
            UsuarioerrorProvider.Clear();
            ContrasenaerrorProvider.Clear();
            ConfirmarContrasenaerrorProvider.Clear();
        }

        private bool ValidarExistente(string aux)
        {
            if (UsuariosBLL.GetListUsuario(aux).Count() > 0)
            {
                MessageBox.Show("Este usuario existe....");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(UsuariotextBox.Text) && string.IsNullOrEmpty(NombretextBox.Text) && string.IsNullOrEmpty(ContraseñatextBox.Text) && string.IsNullOrEmpty(ConfirmartextBox.Text))
            {
                UsuarioerrorProvider.SetError(UsuariotextBox, "Ingrese El Usuario");
                NombreerrorProvider.SetError(NombretextBox, "Ingrese El Nombre");
                ContrasenaerrorProvider.SetError(ContraseñatextBox, "Ingrese Una Contraseña");
                ConfirmarContrasenaerrorProvider.SetError(ConfirmartextBox, "La contraseña no coincide");
                MessageBox.Show("Debe Llenar todos los campos");
            }
            if (string.IsNullOrEmpty(NombretextBox.Text))
            {
                NombreerrorProvider.SetError(NombretextBox, "Ingrese el nombre");
                return false;
            }
            if (string.IsNullOrEmpty(UsuariotextBox.Text))
            {
                UsuarioerrorProvider.SetError(UsuariotextBox, "Ingrese el Usuario");
                return false;
            }
            if (string.IsNullOrEmpty(ContraseñatextBox.Text))
            {
                NombreerrorProvider.Clear();
                ContrasenaerrorProvider.SetError(ContraseñatextBox, "Ingrese contraseña");
                return false;
            }
            if (string.IsNullOrEmpty(ConfirmartextBox.Text))
            {
                NombreerrorProvider.Clear();
                ContrasenaerrorProvider.Clear();
                ConfirmarContrasenaerrorProvider.SetError(ConfirmartextBox, "Confirmar contraseña ");
                return false;
            }
            if (ContraseñatextBox.Text != ConfirmartextBox.Text)
            {
                NombreerrorProvider.Clear();
                ContrasenaerrorProvider.Clear();
                ConfirmarContrasenaerrorProvider.Clear();
                ConfirmarContrasenaerrorProvider.SetError(ConfirmartextBox, "La contraseña no coincide");
                return false;
            }
            return true;
        }


        private void Registro_Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            LlenarClase(usuario);
            if (Validar() && ValidarExistente(NombretextBox.Text))
            {
                UsuariosBLL.Guardar(usuario);
                MessageBox.Show("Guardado con exito!!!!");
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = UsuariosBLL.Buscar((int)IdnumericUpDown.Value);

            if (usuario != null)
            {
                IdnumericUpDown.Value = usuario.UsuarioId;
                UsuariotextBox.Text = usuario.Usuario;
                NombretextBox.Text = usuario.Nombre;
                ContraseñatextBox.Text = usuario.Clave;
            }
            else
            {
                MessageBox.Show("Este Usuario No Existe");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            UsuariosBLL.Eliminar((int)IdnumericUpDown.Value);
            MessageBox.Show("Usuario Eliminado, Correctamente!");
        }
    }
}
