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
    public class EntradaProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            EntradaProductos Entrada = new EntradaProductos();
            Entrada.EntradaId = 1;
            Entrada.Fecha = DateTime.Now;
            Entrada.Cantidad = 10;
            Entrada.ProductoId = 3;


            paso = EntradaProductosBLL.Guardar(Entrada);
            Assert.AreEqual(paso, true);
        }



        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            EntradaProductos Entrada = new EntradaProductos();
            Entrada.EntradaId = 3;
            Entrada.Fecha = DateTime.Now;
            Entrada.Cantidad = 5;
            Entrada.ProductoId = 3;


            paso = EntradaProductosBLL.Modificar(Entrada);
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 3;
            EntradaProductos Entrada = new EntradaProductos();
            Entrada = EntradaProductosBLL.Buscar(id);
            Assert.IsNotNull(Entrada);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = EntradaProductosBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 3;
            paso = EntradaProductosBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }
    }
}
