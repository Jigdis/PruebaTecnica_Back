using Application.DTOs;
using Application.Interface;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Queries.GetAllDirecciones
{
    public class GetAllDireccionesQuery : IRequest<PagedResponse<List<DireccionDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }

        public class GetAllDireccionesQueryHandler : IRequestHandler<GetAllDireccionesQuery, PagedResponse<List<DireccionDto>>>
        {
            private readonly IRepositoryAsync<Direccion> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllDireccionesQueryHandler(IRepositoryAsync<Direccion> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<DireccionDto>>> Handle(GetAllDireccionesQuery request, CancellationToken cancellationToken)
            {
                var direcciones = await _repositoryAsync.ListAsync(new PagedDireccionesSpecification(request.PageSize, request.PageNumber, request.Colonia, request.Ciudad));
                var direccionesDto = _mapper.Map<List<DireccionDto>>(direcciones);

                return new PagedResponse<List<DireccionDto>>(direccionesDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
