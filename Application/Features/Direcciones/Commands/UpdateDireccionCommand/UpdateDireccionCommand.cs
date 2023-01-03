using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Direcciones.Commands.UpdateDireccionCommand
{
    public class UpdateDireccionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string CalleNumero { get; set; }
        public string Colonia { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }

    public class UpdateDireccionCommandHandler : IRequestHandler<UpdateDireccionCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Direccion> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateDireccionCommandHandler(IRepositoryAsync<Direccion> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateDireccionCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if(record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                record.Alias = request.Alias;
                record.CalleNumero = request.CalleNumero;
                record.Colonia = request.Colonia;
                record.CodigoPostal = request.CodigoPostal;
                record.Ciudad= request.Ciudad;
                record.Estado= request.Estado;
                record.Pais = request.Pais;

                await _repositoryAsync.UpdateAsync(record);

                return new Response<int>(record.Id);
            }
        }
    }
}
