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

namespace Proyecto_Final_Aplicada.UI.Reportes
{
    public partial class ReportesProducto : Form
    {
        List<Productos> datos = new List<Productos>();
        public ReportesProducto(List<Productos> log)
        {
            InitializeComponent();
            datos = log;
        }

        private void ReporteLogInViewer_Load(object sender, EventArgs e)
        {
            ReporteProductos abrir = new ReporteProductos();
            abrir.SetDataSource(datos);
            ReporteLogInViewer.ReportSource = abrir;
            ReporteLogInViewer.Refresh();
        }
    }
}
