using Proyecto_Final_Aplicada.IU.Registros;
using Proyecto_Final_Aplicada.UI;
using Proyecto_Final_Aplicada.UI.Consulta;
using Proyecto_Final_Aplicada.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_Aplicada
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_Usuarios().Show();
        }

        private void cambiarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_Login().Show();

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_Cliente().Show();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Consulta_Usuario().Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Consulta_Clientes().Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_Productos().Show();
        }

        private void articulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Consulta_Productos().Show();
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_FacturaDetalle().Show();
        }

        private void entradaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_EntradaProductos().Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Consulta_Factura().Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void entradaDeProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Consulta_EntradaProductos().Show();
        }
    }
}
