using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BPZ.Models;
using BPZ.Dao;
using Moq;
using BPZ.Dtos;

namespace BPZTest.UnitTest
{
    [TestFixture]
    class FacturaUnitTest
    {

        private Mock<FacturaDao> facturaDao = new Mock<FacturaDao>();
        private static List<FacturaDto> lista;
        private static Mock<FacturaDto> facturaDto = new Mock<FacturaDto>();

        [SetUp]
        public void Init()
        {
            DateTime fechaFacturacion = new DateTime(2018, 10, 05);
            DateTime fechaVencimiento = new DateTime(2018, 11, 12);
            facturaDto.Object.codigo = 1582691;
            facturaDto.Object.proveedorId = 2; 
            facturaDto.Object.fechaFacturacion = fechaFacturacion;
            facturaDto.Object.fechaVencimiento = fechaVencimiento;
            facturaDto.Object.descripcion = "Factura correspondiente a la contratacion de servicio de transporte pesado";
            facturaDto.Object.moneda = "Soles";
            facturaDto.Object.subTotal = 1852.36;
            facturaDto.Object.igv = 0.18;
            facturaDto.Object.total = 2185.7848;
            facturaDto.Object.estado = "ACT";

            lista = new List<FacturaDto>()
            {
                new FacturaDto
                {
                    id = 1,
                    codigo = 125887484
                },
                new FacturaDto
                {
                    id = 2,
                    codigo = 125887485
                }
            };
        }


        [Test]
        public void Insertar_Factura_UnitTest()
        {
            facturaDao.Setup(x => x.insertar(It.IsAny<FacturaDto>())).Returns(true);
            bool flag = facturaDao.Object.insertar(facturaDto.Object);
            Assert.IsTrue(flag);
        }

        [Test]
        public void Actualizar_Factura_UnitTest()
        {
            facturaDto.Object.moneda = "Dolares";
            facturaDto.Object.subTotal = 2185.7848;
            facturaDto.Object.total = 2579.2260;
            facturaDao.Setup(x => x.actualizar(It.IsAny<FacturaDto>())).Returns(true);
            bool flag = facturaDao.Object.actualizar(facturaDto.Object);
            Assert.IsTrue(flag);
        }

        [Test]
        public void Eliminar_Factura_UnitTest()
        {
            int facturaEliminadaId = 12;
            facturaDao.Setup(x => x.eliminar(It.IsAny<int>())).Returns(true);
            bool flag = facturaDao.Object.eliminar(facturaEliminadaId);
            Assert.IsTrue(flag);
        }

        [Test]
        public void Obtener_Factura_UnitTest()
        {
            FacturaDto facturaEsperada = new FacturaDto();
            facturaDao.Setup(x => x.obtener(It.IsAny<int>())).Returns(facturaDto.Object);
            facturaEsperada = facturaDao.Object.obtener(facturaDto.Object.id);
            Assert.AreEqual(facturaEsperada.codigo, facturaDto.Object.codigo);
            Assert.AreEqual(facturaEsperada.proveedorId,facturaDto.Object.proveedorId);
            Assert.AreEqual(facturaEsperada.fechaFacturacion, facturaDto.Object.fechaFacturacion);
            Assert.AreEqual(facturaEsperada.fechaVencimiento, facturaDto.Object.fechaVencimiento);
            Assert.AreEqual(facturaEsperada.descripcion, facturaDto.Object.descripcion);
            Assert.AreEqual(facturaEsperada.moneda, facturaDto.Object.moneda);
            Assert.AreEqual(facturaEsperada.subTotal, facturaDto.Object.subTotal);
            Assert.AreEqual(facturaEsperada.igv, facturaDto.Object.igv);
            Assert.AreEqual(facturaEsperada.total, facturaDto.Object.total);
            Assert.AreEqual(facturaEsperada.estado, facturaDto.Object.estado);
        }

        [Test]
        public void Listar_Factura_UnitTest()
        {
            List<FacturaDto> listaEsperada = new List<FacturaDto>();
            facturaDao.Setup(x => x.listar()).Returns(lista);
            listaEsperada = facturaDao.Object.listar();
            Assert.IsTrue(listaEsperada.Count > 0);
            Assert.IsNotNull(listaEsperada);
        }

    }
}
