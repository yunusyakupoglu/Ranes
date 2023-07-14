using MediatR;
using Microsoft.AspNetCore.Http;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Building.UpdateBuilding
{
    public class UpdateBuildingCommandRequest : IRequest<Response<UpdateBuildingCommandResponse>>
    {
        public Guid Id { get; set; }
        public string UpdatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float m2 { get; set; }
        public IFormFile ImgPrimary { get; set; }
        public IFormFile? ImgOne { get; set; }
        public IFormFile? ImgTwo { get; set; }
        public IFormFile? ImgThree { get; set; }
        public IFormFile? ImgFour { get; set; }
        public IFormFile? ImgFive { get; set; }
        public IFormFile? ImgSix { get; set; }
        public IFormFile? ImgSeven { get; set; }
        public IFormFile? ImgEight { get; set; }
        public IFormFile? ImgNine { get; set; }
        public IFormFile? ImgTen { get; set; }
        public Guid CategoryId { get; set; }
        public bool Investment { get; set; }
        public bool CompletedProject { get; set; }
    }
}
