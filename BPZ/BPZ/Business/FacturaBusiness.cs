using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BPZ.Dao;
using BPZ.Dtos;

namespace BPZ.Business
{
    public class FacturaBusiness
    {
        private FacturaDao facturaDao = new FacturaDao();

        public bool insertar(FacturaDto facturaDto)
        {
            return facturaDao.insertar(facturaDto);
        }

        public bool actualizar(FacturaDto facturaDto)
        {
            return facturaDao.actualizar(facturaDto);
        }

        public bool eliminar(int id)
        {
            return facturaDao.eliminar(id);
        }

        public FacturaDto obtener(int id)
        {
            return facturaDao.obtener(id);
        }

        public List<FacturaDto> listar()
        {
            return facturaDao.listar();
        }

    }
}