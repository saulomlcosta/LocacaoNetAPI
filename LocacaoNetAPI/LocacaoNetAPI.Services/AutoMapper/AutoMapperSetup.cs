using AutoMapper;
using LocacaoNetAPI.Application.DTO;
using LocacaoNetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region DTOToDomain

            CreateMap<LocacaoDTO, Locacao>();

            #endregion

            #region DomainToDTO

            CreateMap<Locacao, LocacaoDTO>();

            #endregion
        }
    }
}
