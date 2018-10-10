using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BPZ.Models;
using BPZ.Dtos;

namespace BPZ.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Proveedor, ProveedorDto>();
            CreateMap<ProveedorDto, Proveedor>();
        }
    }
}