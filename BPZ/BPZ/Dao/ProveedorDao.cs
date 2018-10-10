using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BPZ.Models;
using BPZ.Dtos;
using AutoMapper;

namespace BPZ.Dao
{
    public class ProveedorDao
    {
        private static BPZEntities _context = new BPZEntities();

        public ProveedorDao() {}

        public virtual bool actualizar(ProveedorDto entity)
        {
            bool flag = false;
            Proveedor proveedor = new Proveedor();

            try
            {
                proveedor = _context.Proveedors.Where(x => x.id == entity.id).FirstOrDefault();
                Mapper.Map(entity, proveedor);
                _context.SaveChanges();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                Console.WriteLine("Error:" + e.Message);
            }
            return flag;
        }

        public virtual bool eliminar(int id)
        {
            bool flag = false;
            _context = new BPZEntities();
            Proveedor proveedor = new Proveedor();
            try
            {
                proveedor = _context.Proveedors.Where(x => x.id == id).FirstOrDefault();
                proveedor.estado = "INA";
                _context.SaveChanges();
                flag = true;
            }
            catch (Exception ex)
            {
                flag = false;
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

        public virtual ProveedorDto obtener(int id)
        {
            Proveedor proveedor = new Proveedor();
            ProveedorDto proveedorDto = new ProveedorDto();

            try
            {
                proveedor = _context.Proveedors.Where(x => x.id == id).FirstOrDefault();
                proveedorDto = Mapper.Map<Proveedor, ProveedorDto>(proveedor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return proveedorDto;
          
        }

        public virtual bool insertar(ProveedorDto entity)
        {
            bool flag = false;
            Proveedor proveedor = new Proveedor();
            proveedor = Mapper.Map<ProveedorDto, Proveedor>(entity);
            try
            {
                _context.Proveedors.Add(proveedor);
                _context.SaveChanges();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                Console.WriteLine("Error:" + e.Message);
            }
            return flag;
        }

        public virtual List<ProveedorDto> listar()
        {
            using (_context = new BPZEntities())
            {
                var proveedores = _context.Proveedors.Where(x => x.estado == "ACT").ToList();
                var proveedoresDto = Mapper.Map<List<Proveedor>, List<ProveedorDto>>(proveedores);
                return proveedoresDto;
            }
        }
    }
}