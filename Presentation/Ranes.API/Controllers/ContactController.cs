using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ranes.Application.Features.Commands.Contact.CreateContact;
using Ranes.Application.Features.Commands.Contact.DeleteContact;
using Ranes.Application.Features.Commands.Contact.UpdateContact;
using Ranes.Application.Features.Queries.Contact.GetContactById;
using Ranes.Application.Features.Queries.Contact.GetContacts;
using Ranes.Application.Features.Queries.Contact.GetDeletedContacts;

namespace Ranes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            Type controllerType = typeof(ContactController);
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetContactsQueryRequest());
            return CreateActionResultInstance(result);
        }

        [HttpGet("getalldeleteds")]
        public async Task<IActionResult> GetDeletedList()
        {
            var result = await _mediator.Send(new GetDeletedContactsQueryRequest());
            return CreateActionResultInstance(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _mediator.Send(new GetContactByIdQueryRequest { Id = Id });
            return CreateActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateContactCommandRequest createContact)
        {
            var result = await _mediator.Send(createContact);
            return CreateActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactCommandRequest updateContact)
        {
            var result = await _mediator.Send(updateContact);
            return CreateActionResultInstance(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteContactCommandRequest deleteContact)
        {
            var result = await _mediator.Send(deleteContact);
            return CreateActionResultInstance(result);
        }
    }
}
