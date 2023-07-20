using MediatR;
using Microsoft.AspNetCore.Http;
using Ranes.Application.Repositories.File;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.File.GetFiles
{
    public class GetFilesQueryHandler : IRequestHandler<GetFilesQueryRequest, Response<GetFilesQueryResponse>>
    {
        private readonly IFileReadRepository _repository;

        public GetFilesQueryHandler(IFileReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<GetFilesQueryResponse>> Handle(GetFilesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync(b => b.IsDeleted == false, false);
            var result = new GetFilesQueryResponse();
            result.Files = data;
            return Response<GetFilesQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
