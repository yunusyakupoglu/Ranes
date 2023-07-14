using Ranes.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Task<DTOs.Token> CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
