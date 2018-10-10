using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BPZ.Models;
using BPZ.Dtos;
using AutoMapper;

namespace BPZ.Dao
{
    public class FacturaDao
    {
        private static BPZEntities _context;

        public FacturaDao() { }

        public virtual bool insertar(FacturaDto entity)
        {
            bool flag = false;
            Factura factura = new Factura();
            factura = Mapper.Map<FacturaDto, Factura>(entity);
            using (_context = new BPZEntities())
            {
                _context.Facturas.Add(factura);
                _context.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public virtual bool actualizar(FacturaDto entity)
        {
            bool flag = false;
            Factura factura = new Factura();
            using (_context = new BPZEntities())
            {
                factura = _context.Facturas.Where(x => x.id == entity.id).FirstOrDefault();
                Mapper.Map(entity, factura);
                _context.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public virtual bool eliminar(int id)
        {
            bool flag = false;
            Factura factura = new Factura();
            using (_context = new BPZEntities())
            {
                factura = _context.Facturas.Where(x => x.id == id).FirstOrDefault();
                factura.estado = "INA";
                _context.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public virtual FacturaDto obtener(int id)
        {
            FacturaDto facturaDto = new FacturaDto();
            Factura factura = new Factura();
            using (_context = new BPZEntities())
            {
                factura = _context.Facturas.Where(x => x.id == id).FirstOrDefault();
                facturaDto = Mapper.Map<Factura, FacturaDto>(factura);
            }
            return facturaDto;
        }

        public virtual List<FacturaDto> listar()
        {
            List<Factura> facturas = new List<Factura>();
            List<FacturaDto> facturasDto = new List<FacturaDto>();
            using (_context = new BPZEntities())
            {
                 facturas = _context.Facturas.Where(x => x.estado == "ACT").ToList();
                 facturasDto = Mapper.Map<List<Factura>, List<FacturaDto>>(facturas);     
            }
            return facturasDto;
        }

    }
}