using System;
using TechTalk.SpecFlow;
using BPZ.Dao;
using BPZ.Dtos;
using BPZ.Business;
using NUnit.Framework;
using AutoMapper;
using BPZ.Models;

namespace BPZTest.IntegrationTest
{
    [Binding]
    [SetUpFixture]
    public class FacturaIntegrationTest
    {
        private FacturaBusiness facturaBusiness = new FacturaBusiness();
        private FacturaDto facturaDto;
        private bool esNuevo = false;
        private string mensaje = "";
        private int codigo = 0;
        private int proveedorId = 0;
        private string fechaFacturacion = "";
        private string fechaVencimiento = "";
        private string moneda = "";
        private double subTotal = 0.0;
        private double igv = 0.0;
        private double total = 0.0;
        private string estado = "";
        private int id = 0;


        [OneTimeSetUp]
        public void init()
        {
           
        }


        [Given(@"despues de iniciar sesion en la aplicacion")]
        public void GivenDespuesDeIniciarSesionEnLaAplicacion()
        {
            Assert.IsTrue(true);
        }
        
        [When(@"hago clic en el enlace de Facturas")]
        public void WhenHagoClicEnElEnlaceDeFacturas()
        {
            Assert.IsTrue(true);
        }
        
        [When(@"luego hago clic en el boton de Registro")]
        public void WhenLuegoHagoClicEnElBotonDeRegistro()
        {
            esNuevo = true;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo codigo el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoCodigoElValorDe(int p0)
        {
            codigo = p0;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo proveedorId el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoProveedorIdElValorDe(int p0)
        {
            proveedorId = p0;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo fecha facturacion el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoFechaFacturacionElValorDe(string p0)
        {
            fechaFacturacion = p0;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo fecha vencimiento el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoFechaVencimientoElValorDe(string p0)
        {
            fechaVencimiento = p0;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo moneda el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoMonedaElValorDe(string p0)
        {
            moneda = p0;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo subtotal el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoSubtotalElValorDe(Decimal p0)
        {
            subTotal = (double)p0;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo igv el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoIgvElValorDe(Decimal p0)
        {
            igv = (double)p0;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo total el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoTotalElValorDe(Decimal p0)
        {
            total = (double)p0;
            Assert.IsTrue(true);
        }
        
        [When(@"presiono el boton de Guardar")]
        public void WhenPresionoElBotonDeGuardar()
        {
            try
            {
                facturaDto = new FacturaDto();
                facturaDto.codigo = codigo;
                facturaDto.proveedorId = proveedorId;
                facturaDto.fechaFacturacion = DateTime.Parse(fechaFacturacion);
                facturaDto.fechaVencimiento = DateTime.Parse(fechaVencimiento);
                facturaDto.moneda = moneda;
                facturaDto.subTotal = subTotal;
                facturaDto.igv = igv;
                facturaDto.total = total;
                facturaDto.estado = "ACT";
                if (esNuevo)
                {
                    facturaBusiness.insertar(facturaDto);
                    mensaje = "Se registro correctamente la Factura";
                }
                else
                {
                    facturaDto.id = id;
                    facturaBusiness.actualizar(facturaDto);
                    mensaje = "Se actualizo correctamente la Factura";
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
                Console.WriteLine(mensaje);
                Assert.Fail();
            }
        }
        
        [Then(@"el sistema me muestra el mensaje de ""(.*)""")]
        public void ThenElSistemaMeMuestraElMensajeDe(string p0)
        {
            Assert.AreEqual(mensaje, p0);
        }

        [When(@"busco la factura de id ""(.*)"" para seleccionarla")]
        public void WhenBuscoLaFacturaDeIdParaSeleccionarla(int p0)
        {
            facturaDto = facturaBusiness.obtener(p0);
            id = facturaDto.id;
        }

        [When(@"luego hago clic en el boton de Editar")]
        public void WhenLuegoHagoClicEnElBotonDeEditar()
        {
            esNuevo = false;
            Assert.IsTrue(true);
        }

        [Then(@"la nueva pantalla muestra la lista de facturas")]
        public void ThenLaNuevaPantallaMuestraLaListaDeFacturas()
        {
            facturaBusiness.listar();
            Assert.IsTrue(true);
            Assert.IsTrue(facturaBusiness.listar().Count > 0);
        }

        [When(@"hago clic en el boton de Eliminar de la factura con el id ""(.*)""")]
        public void WhenHagoClicEnElBotonDeEliminarDeLaFacturaConElId(int p0)
        {
            facturaBusiness.eliminar(p0);
            mensaje = "Se elimino la Factura";
        }

    }
}
