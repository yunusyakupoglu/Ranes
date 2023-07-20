using MediatR;
using Ranes.Application.Features.Queries.Category.GetCategoryById;
using Ranes.Application.Repositories.File;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.File.GetFileById
{
    public class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQueryRequest, Response<GetFileByIdQueryResponse>>
    {
        private readonly IFileReadRepository _readRepository;

        public GetFileByIdQueryHandler(IFileReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetFileByIdQueryResponse>> Handle(GetFileByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            if (data == null) return Response<GetFileByIdQueryResponse>.Fail("File is not exist.", HttpStatusCode.NotFound);
            var result = new GetFileByIdQueryResponse { File = data };
            return Response<GetFileByIdQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
