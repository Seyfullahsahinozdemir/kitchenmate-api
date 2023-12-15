using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Products.Queries.GetProductById;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;

namespace CleanArchitecture.Core.Features.Table.Queries.GetTableById
{
    public class GetTableByIdQuery: IRequest<Response<Entities.Table>>
    {
        public int Id { get; set; }
        public class GetTableByIdQueryHandler : IRequestHandler<GetTableByIdQuery, Response<Entities.Table>>
        {
            private readonly ITableRepositoryAsync _tableRepository;
            public GetTableByIdQueryHandler(ITableRepositoryAsync tableRepository)
            {
                _tableRepository = tableRepository;
            }
            public async Task<Response<Entities.Table>> Handle(GetTableByIdQuery query, CancellationToken cancellationToken)
            {
                var table = await _tableRepository.GetByIdAsync(query.Id);
                if (table == null) throw new ApiException($"Table Not Found.");
                return new Response<Entities.Table>(table);
            }
        }
    }
}
