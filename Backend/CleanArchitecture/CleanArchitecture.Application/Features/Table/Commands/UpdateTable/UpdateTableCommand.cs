using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Interfaces.Repositories;

namespace CleanArchitecture.Core.Features.Table.Commands.UpdateTable
{
    public class UpdateTableCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand, Response<int>>
        {
            private readonly ITableRepositoryAsync _tableRepository;

            public UpdateTableCommandHandler(ITableRepositoryAsync tableRepository)
            {
                _tableRepository = tableRepository;
            }


            public async Task<Response<int>> Handle(UpdateTableCommand command, CancellationToken cancellationToken)
            {
                var entity = await _tableRepository.GetByIdAsync(command.Id);

                if (entity == null) throw new EntityNotFoundException("table", command.Id);

                entity.Description = command.Description;

                await _tableRepository.UpdateAsync(entity);
                return new Response<int>(entity.Id);
            }
        }
    }
}
