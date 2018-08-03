using Proyecto_Final_Aplicada.DAL;
using Proyecto_Final_Aplicada.Entidades;
using Proyecto_Final_Aplicada.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_Aplicada.UI.Registros
{
    public partial class Registro_FacturaDetalle : Form
    {
        decimal ITBIS = 0;
        decimal Total = 0;
        Expression<Func<Facturas, bool>> filtral = x => 1 == 1;
        public Registro_FacturaDetalle()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void Registro_FacturaDetalle_Load(object sender, EventArgs e)
        {

        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;

        }
        public void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            TotaltextBox.Clear();

            ImportetextBox.Clear();
            SubtotaltextBox.Text = 0.ToString();
            TotaltextBox.Text = 0.ToString();
            ITBIStextBox.Text = 0.ToString();
            DetalledataGridView.DataSource = null;

            ITBIS = 0;
            Total = 0;

            errorProvider1.Clear();
        }

        private Facturas LlenaClase()
        {
            Facturas facturas = new Facturas();

            facturas.FacturaId = Convert.ToInt32(IdnumericUpDown.Value);
            facturas.ClienteId = Convert.ToInt32(ClientecomboBox.SelectedValue);
            facturas.Fecha = FechadateTimePicker.Value;
            facturas.Subtotal = Convert.ToDecimal(SubtotaltextBox.Text);
            facturas.ITBIS = Convert.ToDecimal(ITBIStextBox.Text);
            facturas.Total = Convert.ToDecimal(TotaltextBox.Text);


            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {

                facturas.AgregarDetalle
                    (ToInt(item.Cells["id"].Value),
                     facturas.FacturaId,
                       ToInt(item.Cells["ProductoId"].Value),
                       ToInt(item.Cells["cantidad"].Value),
                    Convert.ToDecimal(item.Cells["precio"].Value),
                    Convert.ToInt32(item.Cells["Importe"].Value)
                  );
            }
            return facturas;
        }

        private void LlenarCampos(Facturas facturas)
        {
            Limpiar();
            IdnumericUpDown.Value = facturas.FacturaId;
            FechadateTimePicker.Value = facturas.Fecha;
            SubtotaltextBox.Text = facturas.Subtotal.ToString();
            ITBIStextBox.Text = facturas.ITBIS.ToString();
            TotaltextBox.Text = facturas.Total.ToString();

            DetalledataGridView.DataSource = facturas.Detalle;

        }

        private void LlenarComboBox()
        {

            Repositorio<Usuarios> usuario = new Repositorio<Usuarios>(new Contexto());
            UsuariocomboBox.DataSource = usuario.GetList(c => true);
            UsuariocomboBox.ValueMember = "UsuarioId";
            UsuariocomboBox.DisplayMember = "Nombre";

            Repositorio<Clientes> cliente = new Repositorio<Clientes>(new Contexto());
            ClientecomboBox.DataSource = cliente.GetList(c => true);
            ClientecomboBox.ValueMember = "ClienteId";
            ClientecomboBox.DisplayMember = "Nombre";

            Repositorio<Productos> producto = new Repositorio<Productos>(new Contexto());
            ProductocomboBox.DataSource = producto.GetList(c => true);
            ProductocomboBox.ValueMember = "ProductoId";
            ProductocomboBox.DisplayMember = "Nombre";
        }

        private void ProductocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in BLL.ProductosBLL.GetList(x => x.Nombre == ProductocomboBox.Text))
            {
                PreciotextBox.Text = item.Precio.ToString();

            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<FacturasDetalles> Detalle = new List<FacturasDetalles>();


            if (DetalledataGridView.DataSource != null)
            {
                Detalle = (List<FacturasDetalles>)DetalledataGridView.DataSource;
            }

            foreach (var item in BLL.ProductosBLL.GetList(x => x.Inventario < CantidadnumericUpDown.Value))
            {

                MessageBox.Show("No Existe Producto Suficiente",
                    "validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ImportetextBox.Text))
            {
                MessageBox.Show("Debe Llenar La cantidad",
                    "validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Detalle.Add(new FacturasDetalles(id: 0,
                    facturaId: (int)IdnumericUpDown.Value,
                    productoId: (int)ProductocomboBox.SelectedValue,
                    cantidad: (int)CantidadnumericUpDown.Value,
                     precio: (int)Convert.ToDecimal(PreciotextBox.Text),
                    importe: (int)Convert.ToDecimal(ImportetextBox.Text)

                    ));

                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = Detalle;

            }
            decimal SubTotal = 0;

            foreach (var item in Detalle)
            {
                SubTotal += item.Importe;
            }

            SubtotaltextBox.Text = SubTotal.ToString();

            ITBIS = BLL.FacturasBLL.CalcularITBIS(Convert.ToDecimal(SubtotaltextBox.Text));

            ITBIStextBox.Text = ITBIS.ToString();

            Total = BLL.FacturasBLL.Total(Convert.ToDecimal(SubtotaltextBox.Text), Convert.ToDecimal(ITBIStextBox.Text));

            TotaltextBox.Text = Total.ToString();
        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ImportetextBox.Text = BLL.FacturasBLL.CalcularImporte(Convert.ToDecimal(PreciotextBox.Text), Convert.ToInt32(CantidadnumericUpDown.Value)).ToString();

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Facturas facturas = BLL.FacturasBLL.Buscar(id);

            if (facturas != null)
            {
                LlenarCampos(facturas);

            }
            else
                MessageBox.Show("No Se Encontro!", "Intente De Nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {

                MessageBox.Show("Debe Llenar Todos Los Campos!",
                    "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                if (BLL.FacturasBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!",
                        "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!",
                        "Intente De Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (Validar(2))
            {
                MessageBox.Show("Debe Agreagar Pruducto Al Grid",
                    "validar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                Facturas facturas = LlenaClase();
                bool Paso = false;

                if (IdnumericUpDown.Value == 0)
                {
                    Paso = BLL.FacturasBLL.Guardar(facturas);
                    errorProvider1.Clear();
                }
                else
                {
                    var P = BLL.FacturasBLL.Buscar(Convert.ToInt32(IdnumericUpDown.Value));
                    if (P != null)
                    {
                        Paso = BLL.FacturasBLL.Modificar(facturas);
                    }

                    errorProvider1.Clear();
                }

                if (Paso)
                {

                    MessageBox.Show("Guardado!!", "Excelente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No Se Puedoe Guardar!!",
                        "Intente De Nuevo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            Facturas facturas = new Facturas();

            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {

                List<FacturasDetalles> Detalle = (List<FacturasDetalles>)DetalledataGridView.DataSource;


                Detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);


                decimal SubTotal = 0;

                foreach (var item in Detalle)
                {
                    SubTotal -= item.Importe;
                }

                SubTotal *= (-1);
                SubtotaltextBox.Text = SubTotal.ToString();

                ITBIS = BLL.FacturasBLL.CalcularITBIS(Convert.ToDecimal(SubtotaltextBox.Text));
                ITBIStextBox.Text = ITBIS.ToString();

                Total = BLL.FacturasBLL.Total(Convert.ToDecimal(SubtotaltextBox.Text), Convert.ToDecimal(ITBIStextBox.Text));

                TotaltextBox.Text = Total.ToString();

                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = Detalle;

            }
        }

        private bool Validar(int error)
        {
            bool paso = false;


            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown,
                   "No Debe dejar Id Vacio");
                paso = true;
            }
            if (error == 2 && string.IsNullOrWhiteSpace(TotaltextBox.Text))
            {
                errorProvider1.SetError(TotaltextBox,
                   "No Debes Dejar El Total Vacio");
                paso = true;
            }
            if (error == 2 && string.IsNullOrWhiteSpace(SubtotaltextBox.Text))
            {
                errorProvider1.SetError(SubtotaltextBox,
                   "No Debes Dejar El SubTotal Vacio");
                paso = true;
            }
            if (error == 2 && string.IsNullOrWhiteSpace(ITBIStextBox.Text))
            {
                errorProvider1.SetError(ITBIStextBox,
                   "No Debes Dejar El ITBIS Vacio");
                paso = true;
            }

            if (error == 2 && DetalledataGridView.RowCount == 0)
            {
                errorProvider1.SetError(DetalledataGridView,
                    "Siempre Debe Agregar Un Prucducto");
                paso = true;
            }

            if (error == 3 && string.IsNullOrEmpty(ImportetextBox.Text))
            {
                errorProvider1.SetError(ImportetextBox,
                    "No Debes Dejar El Importe Vacio");
                paso = true;
            }

            return paso;
        }

        private void Reportebutton_Click(object sender, EventArgs e)
        {
            ReportesRecibos abrir = new ReportesRecibos(BLL.FacturasBLL.GetList(filtral));
            abrir.Show();
        }

        private void ClientecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
