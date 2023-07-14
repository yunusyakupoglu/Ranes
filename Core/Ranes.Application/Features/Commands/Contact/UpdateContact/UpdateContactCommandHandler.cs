using MediatR;
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

namespace Ranes.Application.Features.Commands.Contact.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommandRequest, Response<UpdateContactCommandResponse>>
    {
        private readonly IContactReadRepository _readRepository;
        private readonly IContactWriteRepository _writeRepository;

        public UpdateContactCommandHandler(IContactReadRepository readRepository, IContactWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<UpdateContactCommandResponse>> Handle(UpdateContactCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
            var isThereContactRecord = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            isThereContactRecord.UpdatedBy = request.UpdatedBy;
            isThereContactRecord.UpdatedDate = DateTime.UtcNow;
            isThereContactRecord.Tel = request.Tel;
            isThereContactRecord.Fax = request.Fax;
            isThereContactRecord.PrimaryMail = request.PrimaryMail;
            isThereContactRecord.SecondaryMail = request.SecondaryMail;
            isThereContactRecord.PrimaryAddress = request.PrimaryAddress;
            isThereContactRecord.SecondaryAddress = request.SecondaryAddress;
            isThereContactRecord.Location = request.Location;
            isThereContactRecord.Lat = request.Lat;
            isThereContactRecord.Long = request.Long;

            _writeRepository.Update(isThereContactRecord);
            await _writeRepository.SaveAsync();
            return Response<UpdateContactCommandResponse>.Success(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
