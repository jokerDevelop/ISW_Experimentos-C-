using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BPZ.Dtos
{
    public class FacturaDto
    {
        public int id { get; set; }

        public long codigo { get; set; }

        public int proveedorId { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaFacturacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaVencimiento { get; set; }

        [MaxLength(800)]
        public string descripcion { get; set; }
        [MaxLength(50)]
        public string moneda { get; set; }

        public double subTotal { get; set; }

        public double igv { get; set; }

        public double total { get; set; }

        public string estado { get; set; }

        public double CalcularTotal()
        {
            return (this.subTotal*(1 + igv));
        }
    }
}