using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Table.Commands.CreateTable
{
    public partial class CreateTableCommand : IRequest<Response<int>>
    {
        public string Description { get; set; }
    }
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, Response<int>>
    {
        private readonly ITableRepositoryAsync _tableRepository;
        private readonly IMapper _mapper;
        public CreateTableCommandHandler(ITableRepositoryAsync tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var table = _mapper.Map<Entities.Table>(request);
            table.Active = false.ToString();
            await _tableRepository.AddAsync(table);
            return new Response<int>(table.Id, "Table added successful");
        }
    }
}
