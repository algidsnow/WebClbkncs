using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Login
    {
     
            [Key]
            public string UserName { get; set; }
            [StringLength(20, ErrorMessage = "Do not Exceed 20 char", MinimumLength = 6)]
            public string PassWord { get; set; }
            public int? Roles { get; set; }
        }
    }

