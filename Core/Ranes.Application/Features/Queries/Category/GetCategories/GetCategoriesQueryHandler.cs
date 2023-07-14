using MediatR;
using Ranes.Application.Repositories.Category;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Category.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, Response<GetCategoriesQueryResponse>>
    {

        private readonly ICategoryReadRepository _readRepository;

        public GetCategoriesQueryHandler(ICategoryReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetCategoriesQueryResponse>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetAllAsync(b => b.IsDeleted == false, false);
            var result = new GetCategoriesQueryResponse();
            result.Categories = data;
            return Response<GetCategoriesQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
