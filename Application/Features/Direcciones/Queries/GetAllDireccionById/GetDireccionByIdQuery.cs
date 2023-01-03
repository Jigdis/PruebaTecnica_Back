using Application.DTOs;
using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Queries.GetAllDireccionById
{
    public class GetDireccionByIdQuery : IRequest<Response<DireccionDto>>
    {
        public int Id { get; set; }

        public class GetDireccionByIdQueryHandler : IRequestHandler<GetDireccionByIdQuery, Response<DireccionDto>>
        {
            private readonly IRepositoryAsync<Direccion> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetDireccionByIdQueryHandler(IRepositoryAsync<Direccion> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<DireccionDto>> Handle(GetDireccionByIdQuery request, CancellationToken cancellationToken)
            {
                var record = await _repositoryAsync.GetByIdAsync(request.Id);

                if (record == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }
                else
                {
                    var dto = _mapper.Map<DireccionDto>(record);
                    return new Response<DireccionDto>(dto);
                }
            }
        }
    }
}
