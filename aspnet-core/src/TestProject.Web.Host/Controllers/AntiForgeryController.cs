using Microsoft.AspNetCore.Antiforgery;
using TestProject.Controllers;

namespace TestProject.Web.Host.Controllers
{
    public class AntiForgeryController : TestProjectControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}