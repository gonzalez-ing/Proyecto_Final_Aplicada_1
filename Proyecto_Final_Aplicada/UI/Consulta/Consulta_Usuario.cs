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

namespace Proyecto_Final_Aplicada.UI
{
    public partial class Consulta_Usuario : Form
    {
        public Consulta_Usuario()
        {
            InitializeComponent();
        }

        Expression<Func<Usuarios, bool>> filtro = x => 1 == 1;
        private void BuscarFiltrobutton_Click(object sender, EventArgs e)
        {
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0://Id

                    if (Validar(1))
                    {
                        MessageBox.Show("Llenar Campo ",
                            "PROBLEMAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Digite Un Numero!",
                            "PROBLEMAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        int id = Convert.ToInt32(FiltrartextBox.Text);

                        filtro = x => x.UsuarioId == id;

                        if (BLL.UsuariosBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("No Existe Ese Id",
                                "Favor Revisar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }


                    break;

                case 1://Usuario

                    if (Validar(1))
                    {
                        MessageBox.Show(" Llenar campo ",
                            "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(3))
                    {
                        MessageBox.Show("Digite un Usuario!",
                            "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        filtro = x => x.Usuario.Contains(FiltrartextBox.Text);

                        if (BLL.UsuariosBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("no hay ese Usuario",
                                "favor revisar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;

                case 2://Nombre
                    if (Validar(1))
                    {
                        MessageBox.Show(" Llenar campo ",
                            "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(3))
                    {
                        MessageBox.Show("Digite un Nombre!",
                            "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        filtro = x => x.Nombre.Contains(FiltrartextBox.Text);

                        if (BLL.UsuariosBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("no hay ese Nombre",
                                "favor revisar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    break;

                case 3://Todo
                    filtro = x => true;
                    break;
            }
            ConsultadataGridView.DataSource = UsuariosBLL.GetList(filtro);
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

        private void Consulta_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void Reportebutton_Click(object sender, EventArgs e)
        {

            ReporteUsuario abrir = new ReporteUsuario(BLL.UsuariosBLL.GetList(filtro));
            abrir.Show();
        }
    }
}
