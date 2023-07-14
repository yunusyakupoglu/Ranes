using MediatR;
using Ranes.Application.Features.Commands.Building.UpdateBuilding;
using Ranes.Application.Repositories.Category;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Response<UpdateCategoryCommandResponse>>
    {
        private readonly ICategoryReadRepository _readRepository;
        private readonly ICategoryWriteRepository _writeRepository;

        public UpdateCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereCategoryRecord = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            isThereCategoryRecord.UpdatedBy = request.UpdatedBy;
            isThereCategoryRecord.UpdatedDate = DateTime.UtcNow;
            isThereCategoryRecord.CategoryName = request.CategoryName;

            _writeRepository.Update(isThereCategoryRecord);
            await _writeRepository.SaveAsync();
            return Response<UpdateCategoryCommandResponse>.Success(HttpStatusCode.OK);
        }
    }
}
