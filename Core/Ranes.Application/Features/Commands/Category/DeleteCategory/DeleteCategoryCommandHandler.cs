using MediatR;
using Ranes.Application.Features.Commands.Contact.DeleteContact;
using Ranes.Application.Repositories.Category;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Response<DeleteCategoryCommandResponse>>
    {
        private readonly ICategoryReadRepository _readRepository;
        private readonly ICategoryWriteRepository _writeRepository;

        public DeleteCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<DeleteCategoryCommandResponse>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _readRepository.GetSingleAsync(b => b.Id == request.Id);
            if (categoryToDelete == null) return Response<DeleteCategoryCommandResponse>.Fail("Category is not exist", HttpStatusCode.NotFound);

            categoryToDelete.IsDeleted = true;
            _writeRepository.Update(categoryToDelete);
            await _writeRepository.SaveAsync();
            return Response<DeleteCategoryCommandResponse>.Success(HttpStatusCode.OK);
        }
    }
}
