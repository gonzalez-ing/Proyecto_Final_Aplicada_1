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
    public partial class Registro_Productos : Form
    {
        public Registro_Productos()
        {
            InitializeComponent();
        }

        private bool validar(int error)
        {
            bool errores = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown, "Debe Llenar El Id");
                errores = true;
            }

            if (error == 2 && string.IsNullOrEmpty(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox, "Debe Llenar El Nombre");
                errores = true;
            }

            if (error == 2 && string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                errorProvider1.SetError(DescripciontextBox, "Debe Llenar La Descripcion");
                errores = true;
            }

            if (error == 2 && PrecionumericUpDown.Value == 0)
            {
                errorProvider1.SetError(PrecionumericUpDown, "Debe Llenar El Precio");
                errores = true;
            }


            if (error == 2 && string.IsNullOrEmpty(InventariotextBox.Text))
            {
                errorProvider1.SetError(InventariotextBox, "Debe Llenar El Inventario");
                errores = true;
            }

            return errores;

        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            DescripciontextBox.Clear();
            CostonumericUpDown.Value = 0;
            InventariotextBox.Clear();
            GanancianumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            InventariotextBox.Text = 0.ToString();


            errorProvider1.Clear();
        }

        private Productos Llenaclase()
        {
            Productos productos = new Productos();

            InventariotextBox.Text = 0.ToString();
            productos.ProductoId = Convert.ToInt32(IdnumericUpDown.Value);
            productos.Nombre = NombretextBox.Text;
            productos.Descripcion = DescripciontextBox.Text;
            productos.Costo = Convert.ToDecimal(CostonumericUpDown.Value);
            productos.Ganancia = Convert.ToDecimal(GanancianumericUpDown.Value);
            productos.Precio = Convert.ToDecimal(PrecionumericUpDown.Value);
            productos.Inventario = Convert.ToInt32(InventariotextBox.Text);

            return productos;
        }



        private void Registro_Productos_Load(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Productos productos = Llenaclase();


            if (validar(2))
            {
                MessageBox.Show("Debe Llenar Todos Los Campos");
            }
            else
            {
                if (IdnumericUpDown.Value == 0)
                {
                    paso = BLL.ProductosBLL.Guardar(productos);
                }
                else
                {
                    var P = BLL.ProductosBLL.Buscar(Convert.ToInt32(IdnumericUpDown.Value));
                    if (P != null)
                    {
                        paso = BLL.ProductosBLL.Modificar(productos);
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
                    MessageBox.Show("No Se Puede Guardar!",
                        "Intente De Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show(" Debe Llenar Todos Los Campos");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                Productos productos = BLL.ProductosBLL.Buscar(id);

                if (productos != null)
                {
                    IdnumericUpDown.Value = productos.ProductoId;
                    NombretextBox.Text = productos.Nombre;
                    DescripciontextBox.Text = productos.Descripcion;
                    CostonumericUpDown.Value = productos.Costo;
                    GanancianumericUpDown.Value = productos.Ganancia;
                    PrecionumericUpDown.Value = productos.Precio;
                    InventariotextBox.Text = productos.Inventario.ToString();

                }
                else
                {
                    MessageBox.Show("No Se Puede Encontrado!",
                        "Intente De Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (BLL.ProductosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!",
                        "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No Se Puede Eliminar!",
                        "Intente De Nuevo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal costo = Convert.ToDecimal(CostonumericUpDown.Value);
            decimal precio = Convert.ToDecimal(PrecionumericUpDown.Value);
            decimal ganancia = Convert.ToDecimal(GanancianumericUpDown.Value);

            if (PrecionumericUpDown.Value != 0 && CostonumericUpDown.Value != 0)
            {
                GanancianumericUpDown.Value = BLL.ProductosBLL.CalcularGanancia(costo, precio);
                return;
            }

            if (CostonumericUpDown.Value != 0 && GanancianumericUpDown.Value != 0 && PrecionumericUpDown.Value == 0)
            {

                PrecionumericUpDown.Value = BLL.ProductosBLL.CalcularPrecio(costo, ganancia);
                return;
            }
        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal costo = Convert.ToDecimal(CostonumericUpDown.Value);
            decimal precio = Convert.ToDecimal(PrecionumericUpDown.Value);
            decimal ganancia = Convert.ToDecimal(GanancianumericUpDown.Value);

            if (PrecionumericUpDown.Value != 0 && CostonumericUpDown.Value != 0 && CostonumericUpDown.Value < PrecionumericUpDown.Value)
            {
                GanancianumericUpDown.Value = BLL.ProductosBLL.CalcularGanancia(costo, precio);
                return;

            }
        }

        private void GanancianumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal costo = Convert.ToDecimal(CostonumericUpDown.Value);
            decimal precio = Convert.ToDecimal(PrecionumericUpDown.Value);
            decimal ganancia = Convert.ToDecimal(GanancianumericUpDown.Value);


            if (CostonumericUpDown.Value != 0 && GanancianumericUpDown.Value != 0)
            {

                PrecionumericUpDown.Value = BLL.ProductosBLL.CalcularPrecio(costo, ganancia);
                return;
            }
        }
    }
}