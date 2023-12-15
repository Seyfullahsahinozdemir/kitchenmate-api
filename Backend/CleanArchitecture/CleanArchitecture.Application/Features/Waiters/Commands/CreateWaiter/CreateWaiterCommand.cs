using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;

namespace CleanArchitecture.Core.Features.Waiters.Commands.CreateWaiter
{
    public partial class CreateWaiterCommand: IRequest<Response<int>>
    {
        public string Name { get; set; }
    }

    public class CreateWaiterCommandHandler : IRequestHandler<CreateWaiterCommand, Response<int>>
    {
        private readonly IWaiterRepositoryAsync _waiterRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateWaiterCommandHandler(IWaiterRepositoryAsync waiterRepositoryAsync, IMapper mapper)
        {
            _waiterRepositoryAsync = waiterRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWaiterCommand request, CancellationToken cancellationToken)
        {
            var waiter = _mapper.Map<Waiter>(request);
            await _waiterRepositoryAsync.AddAsync(waiter);
            return new Response<int>(waiter.Id);
        }
    }
}
