using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class PagedDireccionesSpecification : Specification<Direccion>
    {
        public PagedDireccionesSpecification(int pageSize, int pageNumber, string Colonia, string Ciudad)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if(!string.IsNullOrEmpty(Colonia))
                Query.Search(x => x.Colonia, "%" + Colonia + "%");

            if (!string.IsNullOrEmpty(Ciudad))
                Query.Search(x => x.Ciudad, "%" + Ciudad + "%");

        }
    }
}
