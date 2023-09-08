using Business.ValidationRules;
using Core.Models;
using Core.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Repository.Context;
using System.Security.Principal;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private readonly AppDbContext appDbContext;
        public AccountController(AppDbContext _appDbContext, IAccountService accountService)
        {
            _accountService = accountService;
            appDbContext = _appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _accountService.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> AddAccount()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAccount(Account account)
        {

            AccountValidator validationRules = new AccountValidator();
            ValidationResult result = validationRules.Validate(account);
            if (result.IsValid)
            {
                await _accountService.AddAsync(account);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public async Task<IActionResult> DeleteAccount(int id) 
        {
            var values= await _accountService.GetByIdAsync(id);
            await _accountService.RemoveAsync(values);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> EditAccount(int id)
        {
           
            var values = await _accountService.GetByIdAsync(id);
            return View(values);

        }
        [HttpPost]
        public async Task<IActionResult> EditAccount(Account account)
        {

            AccountValidator validationRules = new AccountValidator();
            ValidationResult result = validationRules.Validate(account);
            if (result.IsValid)
            {
                await _accountService.UpdateAsync(account);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }



    }
}
