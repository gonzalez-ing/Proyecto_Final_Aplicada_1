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
    public partial class ReportesFacturas : Form
    {
        List<Facturas> datos = new List<Facturas>();

        public ReportesFacturas(List<Facturas> log)
        {
            InitializeComponent();
            datos = log;
        }

        private void ReporteLogInViewer_Load(object sender, EventArgs e)
        {
            ReporteFacturas abrir = new ReporteFacturas();
            abrir.SetDataSource(datos);
            ReporteLogInViewer.ReportSource = abrir;
            ReporteLogInViewer.Refresh();
        }
    }
}
