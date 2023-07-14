using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ranes.API.CustomAttributes;
using Ranes.Application.Features.Commands.Category.CreateCategory;
using Ranes.Application.Features.Commands.Category.DeleteCategory;
using Ranes.Application.Features.Commands.Category.UpdateCategory;
using Ranes.Application.Features.Commands.Contact.CreateContact;
using Ranes.Application.Features.Commands.Contact.DeleteContact;
using Ranes.Application.Features.Commands.Contact.UpdateContact;
using Ranes.Application.Features.Queries.Category.GetCategories;
using Ranes.Application.Features.Queries.Category.GetCategoryById;
using Ranes.Application.Features.Queries.Category.GetDeletedCategories;
using Ranes.Domain.Entities.Common.Enums.AuthenticationEnums;

namespace Ranes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            Type controllerType = typeof(CategoryController);
            _mediator = mediator;
        }

        [Auth(PageName.Category)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetCategoriesQueryRequest());
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Category)]
        [HttpGet("getalldeleteds")]
        public async Task<IActionResult> GetDeletedList()
        {
            var result = await _mediator.Send(new GetDeletedCategoriesQueryRequest());
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Category)]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQueryRequest { Id = Id });
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Category)]
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryCommandRequest createCategory)
        {
            var result = await _mediator.Send(createCategory);
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Category)]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest updateCategory)
        {
            var result = await _mediator.Send(updateCategory);
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Category)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryCommandRequest deleteCategory)
        {
            var result = await _mediator.Send(deleteCategory);
            return CreateActionResultInstance(result);
        }
    }
}
