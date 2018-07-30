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
    public partial class Registro_Cliente : Form
    {
        public Registro_Cliente()
        {
            InitializeComponent();
        }

        private void Registro_Cliente_Load(object sender, EventArgs e)
        {

        }

        public Clientes LlenarClase()
        {
            Clientes clientes = new Clientes();

            clientes.ClienteId = Convert.ToInt32(IdnumericUpDown.Value);
            clientes.Nombre = NombretextBox.Text;
            clientes.Direccion = DirecciontextBox.Text;
            clientes.Cedula = CedulaTextBox.Text;
            clientes.Telefono = TelefonoTextBox.Text;

            return clientes;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            CedulaTextBox.Clear();
            DirecciontextBox.Clear();
            TelefonoTextBox.Clear();
 
        }

        private void LimpiarProvider()
        {
            IdErrorProvider.Clear();
            OtroErrorProvider.Clear();
        }

        public bool Validar(int error)
        {
            bool paso = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                IdErrorProvider.SetError(IdnumericUpDown, "Debe Ingresar Un Id");
                paso = true;
            }
            if (error == 2 && NombretextBox.Text == string.Empty)
            {
                OtroErrorProvider.SetError(NombretextBox, "Debe Ingresar Un Nombre");
                paso = true;
            }
            if (error == 2 && DirecciontextBox.Text == string.Empty)
            {
                OtroErrorProvider.SetError(DirecciontextBox, "Debe Ingresar Una Direccion");
                paso = true;
            }
            if (error == 2 && CedulaTextBox.MaskFull == false)
            {

                OtroErrorProvider.SetError(CedulaTextBox, "Debe Ingresar Una Cedula");
                paso = true;
            }
            if (error == 2 && TelefonoTextBox.MaskFull == false)
            {

                OtroErrorProvider.SetError(TelefonoTextBox, "Debe Ingresar Un Telefono");
                paso = true;
            }

            return paso;

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Clientes clientes = BLL.ClientesBLL.Buscar(id);

            if (clientes != null)
            {

                NombretextBox.Text = clientes.Nombre;
                DirecciontextBox.Text = clientes.Direccion;
                CedulaTextBox.Text = clientes.Cedula;
                TelefonoTextBox.Text = clientes.Telefono;
                FechadateTimePicker.Value = clientes.Fecha;


            }
            else
                MessageBox.Show("No se puede encontrar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Clientes clientes = ClientesBLL.Buscar((int)IdnumericUpDown.Value);

            if (Validar(2))
            {
                if (clientes == null)
                {
                    if (ClientesBLL.Guardar(LlenarClase()))
                        MessageBox.Show("Guardado Con Exito");
                    else
                        MessageBox.Show("El Cliente No Se Guardo");
                }
                else
                {
                    if (ClientesBLL.Modificar(LlenarClase()))
                        MessageBox.Show("Modificado Con Exito");
                    else
                        MessageBox.Show("El Cliente No Se Modifico");
                }
            }
            else
                LimpiarProvider();
        }
    

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.ClientesBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se puede eliminar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarProvider();
        }
        
    }
}
