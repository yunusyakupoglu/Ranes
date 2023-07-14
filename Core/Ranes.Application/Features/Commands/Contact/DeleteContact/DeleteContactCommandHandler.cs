using MediatR;
using Ranes.Application.Features.Commands.Building.DeleteBuilding;
using Ranes.Application.Features.Commands.Building.UpdateBuilding;
using Ranes.Application.Repositories.Building;
using Ranes.Application.Repositories.Contact;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Contact.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommandRequest, Response<DeleteContactCommandResponse>>
    {
        private readonly IContactReadRepository _readRepository;
        private readonly IContactWriteRepository _writeRepository;

        public DeleteContactCommandHandler(IContactReadRepository readRepository, IContactWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<DeleteContactCommandResponse>> Handle(DeleteContactCommandRequest request, CancellationToken cancellationToken)
        {
            var contactToDelete = await _readRepository.GetSingleAsync(b => b.Id == request.Id);
            if (contactToDelete == null) return Response<DeleteContactCommandResponse>.Fail("Contact is not exist", HttpStatusCode.NotFound);

            contactToDelete.IsDeleted = true;
            _writeRepository.Update(contactToDelete);
            await _writeRepository.SaveAsync();
            return Response<DeleteContactCommandResponse>.Success(HttpStatusCode.OK);
        }
    }
}
