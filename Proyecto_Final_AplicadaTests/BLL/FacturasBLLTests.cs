using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final_Aplicada.BLL;
using Proyecto_Final_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Aplicada.BLL.Tests
{
    [TestClass()]
    public class FacturasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Facturas facturas = new Facturas();
            facturas.FacturaId = 3;
            facturas.ClienteId = 4;
            facturas.Fecha = DateTime.Now;
            facturas.Subtotal = 400;
            facturas.ITBIS = 108;
            facturas.Total = 608;

            paso = FacturasBLL.Guardar(facturas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {

            bool paso = false;
            Facturas facturas = new Facturas();
            facturas.FacturaId = 3;
            facturas.ClienteId = 4;
            facturas.Fecha = DateTime.Now;
            facturas.Subtotal = 500;
            facturas.ITBIS = 250;
            facturas.Total = 5250;

            paso = FacturasBLL.Modificar(facturas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Facturas facturas = new Facturas();
            facturas = FacturasBLL.Buscar(3);
            Assert.IsNotNull(facturas);
        }

        [TestMethod()]
        public void GetListTest()
        {

            var Lista = FacturasBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 3;
            paso = FacturasBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }

    }
}