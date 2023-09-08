using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AccountService : ServiceManager<Account>, IAccountService
    {
        public AccountService(IGenericRepository<Account> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
