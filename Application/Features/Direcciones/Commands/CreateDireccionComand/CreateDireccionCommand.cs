using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Direcciones.Commands.CreateDireccionComand
{
    public class CreateDireccionCommand : IRequest<Response<int>>
    {
        public string Alias { get; set; }
        public string CalleNumero { get; set; }
        public string Colonia { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }

    public class CreateDireccionCommandHandler : IRequestHandler<CreateDireccionCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Direccion> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateDireccionCommandHandler(IRepositoryAsync<Direccion> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync= repositoryAsync;
            _mapper= mapper;
        }

        public async Task<Response<int>> Handle(CreateDireccionCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Direccion>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);

            return new Response<int>(data.Id);
        }
    }
}
