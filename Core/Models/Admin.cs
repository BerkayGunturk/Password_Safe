using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Admin
	{
        [Key]
        public int AdminID { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
