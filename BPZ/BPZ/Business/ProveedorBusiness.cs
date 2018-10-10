using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BPZ.Dao;
using BPZ.Dtos;

namespace BPZ.Business
{
    public class ProveedorBusiness
    {
        private ProveedorDao proveedorDao = new ProveedorDao();

        public bool insertar(ProveedorDto proveedorDto)
        {
            return proveedorDao.insertar(proveedorDto);
        }

        public bool actualizar(ProveedorDto proveedorDto)
        {
            return proveedorDao.actualizar(proveedorDto);
        }

        public bool eliminar(int id)
        {
            return proveedorDao.eliminar(id);
        }

        public ProveedorDto obtener(int id)
        {
            return proveedorDao.obtener(id);
        }

        public List<ProveedorDto> listar()
        {
            return proveedorDao.listar();
        }
    }
}