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
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Clientes clientes = new Clientes();
            clientes.ClienteId = 1;
            clientes.Nombre = "Jose";
            clientes.Direccion = "Salcedo";
            clientes.Cedula = "402181282";
            clientes.Telefono = "8092265260";

            paso = ClientesBLL.Guardar(clientes);
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Clientes clientes = new Clientes();
            clientes.ClienteId = 1;
            clientes.Nombre = "Jose";
            clientes.Direccion = "Tenares";
            clientes.Cedula = "402562160";
            clientes.Telefono = "8092265260";

            paso = ClientesBLL.Modificar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Clientes clientes = new Clientes();
            clientes = ClientesBLL.Buscar(id);
            Assert.IsNotNull(clientes);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = ClientesBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 1;
            bool paso;
            paso = ClientesBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }
    }
}
