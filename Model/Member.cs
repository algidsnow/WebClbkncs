using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMember { get; set; }
        public string name { get; set; }

        public string position { get; set; }

        public  int age { get; set; }

        public string address { get; set; }

        public int PhoneNumber { get; set; }

        public string UrlPresentMember { get; set; }

        public int prioritize { get; set; }

        public int status { get; set; }
    }
}
