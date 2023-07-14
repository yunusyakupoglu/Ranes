using MediatR;
using Ranes.Application.Features.Queries.Contact.GetContactById;
using Ranes.Application.Repositories.Category;
using Ranes.Application.Repositories.Contact;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Category.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, Response<GetCategoryByIdQueryResponse>>
    {
        private readonly ICategoryReadRepository _readRepository;

        public GetCategoryByIdQueryHandler(ICategoryReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetCategoryByIdQueryResponse>> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            if (data == null) return Response<GetCategoryByIdQueryResponse>.Fail("Category is not exist.", HttpStatusCode.NotFound);
            var result = new GetCategoryByIdQueryResponse { Category = data };
            return Response<GetCategoryByIdQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
