using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BPZ.Dtos
{
    public class ProveedorDto
    {
        public int id { get; set; }

        [MaxLength(150)]
        public string nombre { get; set; }

        [MaxLength(3)]
        public string estado { get; set; }         
    }
}