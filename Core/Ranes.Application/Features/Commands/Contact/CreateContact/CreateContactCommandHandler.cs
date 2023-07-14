using MediatR;
using Ranes.Application.Features.Commands.Building.UpdateBuilding;
using Ranes.Application.Features.Commands.Category.CreateCategory;
using Ranes.Application.Repositories.Building;
using Ranes.Application.Repositories.Contact;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Contact.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, Response<CreateContactCommandResponse>>
    {
        private readonly IContactReadRepository _readRepository;
        private readonly IContactWriteRepository _writeRepository;

        public CreateContactCommandHandler(IContactReadRepository readRepository, IContactWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<CreateContactCommandResponse>> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var addedContact = new Domain.Entities.Contact
            {
                CreatedBy = request.CreatedBy,
                Tel = request.Tel,
                Fax = request.Fax,
                PrimaryAddress = request.PrimaryAddress,
                SecondaryAddress = request.SecondaryAddress,
                PrimaryMail = request.PrimaryMail,
                SecondaryMail = request.SecondaryMail,
                Location = request.Location,
                Lat = request.Lat,
                Long = request.Long,
                IsDeleted = false
            };

            await _writeRepository.AddAsync(addedContact);
            int status = await _writeRepository.SaveAsync();

            if (status == 1)
                return Response<CreateContactCommandResponse>.Success(new() { Message = "Contact added successfully" }, HttpStatusCode.Created);

            return Response<CreateContactCommandResponse>.Fail("Failed to add building. Please try again.", HttpStatusCode.BadRequest);
        }
    }
}
