using AutoMapper;
using Gen06_23EjemploAPI.DTOs;
using Gen06_23EjemploAPI.Models;
using System.Collections.Generic;

namespace Gen06_23EjemploAPI.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CAerolinea, AerolineaDTO>().ReverseMap();
            //CreateMap<Aerolinea, AerolineaDTOConAviones>()
            //    .ForMember(aerolineaDTO => aerolineaDTO.Aviones, options => options.MapFrom(MapAviones));
            CreateMap<CAerolinea, AerolineaCreateDTO>().ReverseMap();
            CreateMap<CAerolinea, AerolineaUpdateDTO>().ReverseMap();
        }

        //private List<AvionDTO> MapAviones(Aerolinea aerolinea, AerolineaDTOConAviones aerolineaDTO)
        //{
        //    var listado = new List<AvionDTO>();
        //    if (aerolinea.Aviones == null)
        //    {
        //        return listado;
        //    }
        //    foreach (var avion in aerolinea.Aviones)
        //    {
        //        listado.Add(new AvionDTO()
        //        {
        //            Id = avion.Id,
        //            NumeroRegistro = avion.NumeroRegistro,
        //            Tipo = avion.Tipo,
        //            Modelo = avion.Modelo,
        //            CodigoModelo = avion.CodigoModelo,
        //            Capacidad = avion.Capacidad,
        //            FechaPrimerVuelo = avion.FechaPrimerVuelo,
        //            NumMotores = avion.NumMotores,
        //            Antiguedad = avion.Antiguedad,
        //            Estatus = avion.Estatus,
        //            AerolineaId = avion.AerolineaID
        //        });
        //    }

        //    return listado;

        //}

    }
}
