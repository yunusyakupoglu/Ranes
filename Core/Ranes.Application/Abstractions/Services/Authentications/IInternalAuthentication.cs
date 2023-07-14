using Ranes.Domain.Entities.Common.Enums.AuthenticationEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<DTOs.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);
        Task<bool> Auth(PageName pageName, string token, OperationType operationType);
    }
}
