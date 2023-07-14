using MediatR;
using Ranes.Application.Features.Commands.Building.CreateBuilding;
using Ranes.Application.Repositories.About;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.About.CreateAbout
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommandRequest, Response<CreateAboutCommandResponse>>
    {
        private readonly IAboutReadRepository _readRepository;
        private readonly IAboutWriteRepository _writeRepository;

        public CreateAboutCommandHandler(IAboutReadRepository readRepository, IAboutWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<CreateAboutCommandResponse>> Handle(CreateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var addedAbout = new Domain.Entities.About
            {
                Id = Guid.NewGuid(),
                CreatedBy = request.CreatedBy,
                AboutUs = request.AboutUs,
                OurHistory = request.OurHistory,
                OurVision = request.OurVision,
                OurMission = request.OurMission,
                IsDeleted = false
            };

            await _writeRepository.AddAsync(addedAbout);
            int status = await _writeRepository.SaveAsync();

            if (status == 1)
                return Response<CreateAboutCommandResponse>.Success(new() { Message = "About added successfully" }, HttpStatusCode.Created);

            return Response<CreateAboutCommandResponse>.Fail("Failed to add building. Please try again.", HttpStatusCode.BadRequest);
        }
    }
}
