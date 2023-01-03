using Application.DTOs;
using Application.Features.Direcciones.Commands.CreateDireccionComand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Direccion, DireccionDto>();
            #endregion

            #region Commands
            CreateMap<CreateDireccionCommand, Direccion>();
            #endregion
        }
    }
}
