using AutoMapper;
using c_sharp_web_api_heorku.DTOs;
using c_sharp_web_api_heorku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_web_api_heorku.Mapping
{
    public class MappingEmpresas: Profile
    {
        public MappingEmpresas()
        {
            CreateMap<Empresas, EmpresasDto>()
                .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome))
                .ForMember(dest => dest.razaoSocial, map => map.MapFrom(src => src.razao_social));
        }
    }
}
