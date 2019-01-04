using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;

namespace VikingNotes.UnitTest.Extentions
{
    public static class UnitTestExtensions
    {
        public static void MockCurrentUser(this ApiController controller, string userId, string username)
        {
            // need to create an identity object before creating an IPrinciple object
            var identity = new GenericIdentity(username);

            // need to add some claims to this object
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId));

            // creating a generic principle object. since there is no role set, therefor it is null
            var principal = new GenericPrincipal(identity, null);

            controller.User = principal;
        }
    }
}
