using MediatR;
using Ranes.Application.Features.Queries.Category.GetCategories;
using Ranes.Application.Repositories.Category;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Category.GetDeletedCategories
{
    public class GetDeletedCategoriesQueryHandler : IRequestHandler<GetDeletedCategoriesQueryRequest, Response<GetDeletedCategoriesQueryResponse>>
    {

        private readonly ICategoryReadRepository _readRepository;

        public GetDeletedCategoriesQueryHandler(ICategoryReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetDeletedCategoriesQueryResponse>> Handle(GetDeletedCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetAllAsync(b => b.IsDeleted == true, false);
            var result = new GetDeletedCategoriesQueryResponse();
            result.Categories = data;
            return Response<GetDeletedCategoriesQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
