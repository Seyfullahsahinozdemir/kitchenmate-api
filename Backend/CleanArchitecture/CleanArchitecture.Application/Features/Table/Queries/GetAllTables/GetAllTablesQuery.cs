using AutoMapper;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Table.Queries.GetAllTables
{
    public class GetAllTablesQuery : IRequest<IList<GetAllTablesViewModel>>
    {
    }

    public class GetAllTablesQueryHandler : IRequestHandler<GetAllTablesQuery, IList<GetAllTablesViewModel>>
    {
        private readonly ITableRepositoryAsync _tableRepository;
        private readonly IMapper _mapper;
        public GetAllTablesQueryHandler(ITableRepositoryAsync tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllTablesViewModel>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
        {
            var tables = await _tableRepository.GetAllAsync();
            IList<GetAllTablesViewModel> result = new List<GetAllTablesViewModel>();
            foreach (var table in tables)
            {
                result.Add(new GetAllTablesViewModel
                {
                    Id = table.Id,
                    Description = table.Description,
                    Active = table.Active
                });
            }

            return result;
        }
    }
}
