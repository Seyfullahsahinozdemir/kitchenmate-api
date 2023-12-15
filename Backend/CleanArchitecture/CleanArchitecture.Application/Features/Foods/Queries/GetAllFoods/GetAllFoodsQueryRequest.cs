using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CleanArchitecture.Core.Features.Foods.Queries.GetAllFoods
{
    public class GetAllFoodsQueryRequest: IRequest<IList<GetAllFoodQueryResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
