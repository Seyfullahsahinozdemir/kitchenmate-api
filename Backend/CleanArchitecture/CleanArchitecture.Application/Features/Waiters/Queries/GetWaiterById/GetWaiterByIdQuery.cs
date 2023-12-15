using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;

namespace CleanArchitecture.Core.Features.Waiters.Queries.GetWaiterById
{
    public class GetWaiterByIdQuery: IRequest<Response<Waiter>>
    {
        public int Id { get; set; }
        public class GetWaiterByIdQueryHandler: IRequestHandler<GetWaiterByIdQuery, Response<Waiter>>
        {
            private readonly IWaiterRepositoryAsync _waiterRepositoryAsync;
            public async Task<Response<Waiter>> Handle(GetWaiterByIdQuery request, CancellationToken cancellationToken)
            {
                var waiter = await _waiterRepositoryAsync.GetByIdAsync(request.Id);
                if (waiter == null) throw new ApiException($"Waiter Not Found.");
                return new Response<Waiter>(waiter);
            }
        }
    }
}
