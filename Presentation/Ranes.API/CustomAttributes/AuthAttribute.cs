using Ranes.Domain.Entities.Common.Enums.AuthenticationEnums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Emit;

namespace Ranes.API.CustomAttributes
{
    public class AuthAttribute : ActionFilterAttribute
    {
        private PageName _pageName;
        private OperationType _operationType;
        private string _authToken;
        // operationType

        //Fake Data 
        private Dictionary<PageName, string> _rolePageDB;
        public AuthAttribute(PageName pageName, string authToken ="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwicm9sZSI6ImFkbWluIn0.WP_a4l9blIQDOu3RTONp6f9R3TEGsOET3_KZMz4vRRA")
        {
            _pageName = pageName;
            _authToken = authToken;
            _rolePageDB = new Dictionary<PageName, string>() { 
                { PageName.Building,"admin"},
                { PageName.Contact,"admin"},
                { PageName.Category,"admin"},
                { PageName.About,"admin"},
                { PageName.File,"admin"},
            };
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Normalde bu şekilde handle edilecek 

            // var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var token = _authToken;
            var handler = new JsonWebTokenHandler();
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            string role = jwt.Claims.First(c => c.Type == "role").Value;

            //isAuth?
            //isRoleAccess?
            if (!CheckRoleAccess(_pageName, role))
                context.Result = new UnauthorizedResult();

            base.OnActionExecuting(context);



            //user'ın rollerinin herhangi birin
        }

        private bool CheckRoleAccess(PageName pageName,string role)
        {
            if(_rolePageDB[pageName] == role)
                return true;
            return false;
        }
    }
}
