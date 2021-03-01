namespace ElisStore.Web.Areas.Administration.Controllers
{
    using ElisStore.Common;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]

    public class AdministrationController : Controller
    {
    }
}
