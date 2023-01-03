using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Direcciones.Commands.DeleteDireccionCommand
{
    public class DeleteDireccionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

    }

    public class DeleteDireccionCommandHandler : IRequestHandler<DeleteDireccionCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Direccion> _repositoryAsync;

        public DeleteDireccionCommandHandler(IRepositoryAsync<Direccion> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteDireccionCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {

                await _repositoryAsync.DeleteAsync(record);

                return new Response<int>(record.Id);
            }
        }
    }
}
