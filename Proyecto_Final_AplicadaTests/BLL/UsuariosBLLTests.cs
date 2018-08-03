using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final_Aplicada.BLL;
using Proyecto_Final_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AplicadaTests.BLL
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 1;
            usuarios.Nombre = "Adrian";
            usuarios.Usuario = "Admin";
            usuarios.Clave = "1234";

            paso = UsuariosBLL.Guardar(usuarios);
            Assert.AreEqual(paso, true);
        }


        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 1;
            usuarios.Nombre = "Esteban";
            usuarios.Usuario = "Empleado";
            usuarios.Clave = "4321";

            paso = UsuariosBLL.Modificar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Usuarios usuarios = new Usuarios();
            usuarios = UsuariosBLL.Buscar(id);
            Assert.IsNotNull(usuarios);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = UsuariosBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 1;
            paso = UsuariosBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }

    }
}
