using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Exceptions;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Features.Table.Commands.DeleteTableById
{
    public class DeleteTableByIdCommand: IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteTableByIdCommandHandler : IRequestHandler<DeleteTableByIdCommand, Response<int>>
        {
            private readonly ITableRepositoryAsync _tableRepository;

            public DeleteTableByIdCommandHandler(ITableRepositoryAsync tableRepository)
            {
                _tableRepository = tableRepository;
            }


            public async Task<Response<int>> Handle(DeleteTableByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _tableRepository.GetByIdAsync(command.Id);

                if (entity == null)
                {
                    throw new ApiException($"Table not found.");
                }

                await _tableRepository.DeleteAsync(entity);

                return new Response<int>(entity.Id);
            }
        }
    }
}
