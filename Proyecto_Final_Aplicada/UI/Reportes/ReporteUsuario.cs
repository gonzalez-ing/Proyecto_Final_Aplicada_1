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
    public partial class ReporteUsuario : Form
    {
        List<Usuarios> datos = new List<Usuarios>();
        public ReporteUsuario(List<Usuarios> log)
        {
            InitializeComponent();
            datos = log;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReporteUsuarios abrir = new ReporteUsuarios();
            abrir.SetDataSource(datos);
            ReporteLogInViewer.ReportSource = abrir;
            ReporteLogInViewer.Refresh();
        }
    }
}
