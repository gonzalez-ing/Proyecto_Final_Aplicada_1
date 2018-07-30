using Proyecto_Final_Aplicada.DAL;
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

namespace Proyecto_Final_Aplicada.UI.Registros
{
    public partial class Registro_EntradaProductos : Form
    {
        public Registro_EntradaProductos()
        {
            InitializeComponent();
            LlenaComboBox();
        }

        private void Registro_EntradaProductos_Load(object sender, EventArgs e)
        {

        }

        private void LlenaComboBox()
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>(new Contexto());
            ProductocomboBox.DataSource = repositorio.GetList(c => true);
            ProductocomboBox.ValueMember = "ProductoId";
            ProductocomboBox.DisplayMember = "Nombre";
        }

        private bool validar(int error)
        {
            bool errores = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown, "Llenar Id");
                errores = true;
            }

            if (error == 2 && CantidadnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(CantidadnumericUpDown, "Llene Nombre");
                errores = true;
            }


            return errores;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            CantidadnumericUpDown.Value = 0;


            errorProvider1.Clear();
        }

        private EntradaProductos Llenaclase()
        {
            EntradaProductos entrada = new EntradaProductos();
            entrada.EntradaId = Convert.ToInt32(IdnumericUpDown.Value);
            entrada.ProductoId = (int)ProductocomboBox.SelectedValue;
            entrada.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);


            return entrada;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            EntradaProductos entrada = Llenaclase();


            if (validar(2))
            {
                MessageBox.Show("Debe Llenar Todos Los Campos");
            }
            else
            {
                if (IdnumericUpDown.Value == 0)
                {
                    paso = BLL.EntradaProductosBLL.Guardar(entrada);
                }
                else
                {
                    var P = BLL.EntradaProductosBLL.Buscar(Convert.ToInt32(IdnumericUpDown.Value));
                    if (P != null)
                    {
                        paso = BLL.EntradaProductosBLL.Modificar(entrada);
                    }
                }
                Limpiar();
                errorProvider1.Clear();
                if (paso)
                {
                    MessageBox.Show("Guardado!",
                        "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puede Guardar!",
                        "Intenta de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("Debe Llenar Todos Los Campos");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                EntradaProductos entrada = BLL.EntradaProductosBLL.Buscar(id);

                if (entrada != null)
                {
                    IdnumericUpDown.Value = entrada.EntradaId;
                    ProductocomboBox.SelectedValue = entrada.ProductoId;
                    CantidadnumericUpDown.Value = entrada.Cantidad;



                }
                else
                {
                    MessageBox.Show("No Fue Encontrado!",
                        "Buscar de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("Debe Llenar Todos Los Campos");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);

                if (BLL.EntradaProductosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!",
                        "Execelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se Pudo Eliminar!",
                        "Intenta de nuevo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
