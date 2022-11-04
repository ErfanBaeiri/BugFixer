using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Controllers
{
    public class BaseController : Controller
    {
        public static string SucessMessage = "SucessMessage";
        public static string WarningMessage = "WarningMessage";
        public static string InfoMessage = "InfoMessage";
        public static string ErrorMessage = "ErrorMessage";
    }
}
