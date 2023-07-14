using Ranes.Domain.Entities.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ranes.API.Controllers
{
 
    public class BaseApiController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int?)response.StatusCode
            };
        }
    }
}
