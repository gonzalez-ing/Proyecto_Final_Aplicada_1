using Proyecto_Final_Aplicada.BLL;
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

namespace Proyecto_Final_Aplicada.UI.Consulta
{
    public partial class Consulta_EntradaProductos : Form
    {
        public Consulta_EntradaProductos()
        {
            InitializeComponent();
        }

        Expression<Func<EntradaProductos, bool>> filtral = x => 1 == 1;
        private void BuscarFiltrobutton_Click(object sender, EventArgs e)
        {
            int Id;
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0://EntrdaId
                    Id = Convert.ToInt32(FiltrartextBox.Text);
                    filtral = x => x.EntradaId == Id
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
             
                case 1://Cantidad
                    Id = Convert.ToInt32(FiltrartextBox.Text);
                    filtral = x => x.Cantidad == Id
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;

                case 2://Todos
                    filtral = x => true;
                    break;
            }
            ConsultadataGridView.DataSource = EntradaProductosBLL.GetList(filtral);
        }

        private bool Validar(int error)
        {
            bool paso = false;
            int num = 0;

            if (error == 1 && string.IsNullOrEmpty(FiltrartextBox.Text))
            {
                MyerrorProvider.SetError(FiltrartextBox, "siempre, LLenar Campo!");
                paso = true;
            }
            if (error == 2 && int.TryParse(FiltrartextBox.Text, out num) == false)
            {
                MyerrorProvider.SetError(FiltrartextBox, "Digite un numero");
                paso = true;
            }

            if (error == 3 && int.TryParse(FiltrartextBox.Text, out num) == true)
            {
                MyerrorProvider.SetError(FiltrartextBox, "Digite cararcter");
                paso = true;
            }

            return paso;
        }

        private void Reportebutton_Click(object sender, EventArgs e)
        {
            ReportesEntradaProducto abrir = new ReportesEntradaProducto (BLL.EntradaProductosBLL.GetList(filtral));
            abrir.Show();
        }
    }
}
