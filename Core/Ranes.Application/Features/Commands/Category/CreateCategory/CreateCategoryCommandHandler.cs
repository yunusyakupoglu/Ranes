using MediatR;
using Ranes.Application.Features.Commands.Building.CreateBuilding;
using Ranes.Application.Repositories.Category;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, Response<CreateCategoryCommandResponse>>
    {
        private readonly ICategoryReadRepository _readRepository;
        private readonly ICategoryWriteRepository _writeRepository;

        public CreateCategoryCommandHandler(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<CreateCategoryCommandResponse>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var addedCategory = new Domain.Entities.Category
            {
                CreatedBy = request.CreatedBy,
                CategoryName = request.CategoryName,
                IsDeleted = false
            };

            await _writeRepository.AddAsync(addedCategory);
            int status = await _writeRepository.SaveAsync();

            if (status == 1)
                return Response<CreateCategoryCommandResponse>.Success(new() { Message = "Category added successfully" }, HttpStatusCode.Created);

            return Response<CreateCategoryCommandResponse>.Fail("Failed to add building. Please try again.", HttpStatusCode.BadRequest);
        }
    }
}
