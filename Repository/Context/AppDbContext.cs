using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository.Context
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
	{
	
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-5U8T0LG\\SQLEXPRESS;database=PasswordSafe;integrated security = true");
		}
		public DbSet<Account> Accounts { get; set; }

		public DbSet<Admin> Admins { get; set; }
        

    }
}

