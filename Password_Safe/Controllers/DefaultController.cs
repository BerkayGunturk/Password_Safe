using Business.Services;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Repository.Context;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Password_Safe.Controllers
{
    public class DefaultController : Controller
    {

        private IAccountService _accountService;
        private readonly AppDbContext appDbContext;
        public DefaultController( AppDbContext _appDbContext, IAccountService accountService)
        {
            _accountService = accountService;
            appDbContext = _appDbContext;
        }
        public IActionResult Index()
        {
            return View(_accountService.GetAllAsync());
        }
    }
}
