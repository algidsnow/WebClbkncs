using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class NewsImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsImageId { get; set; }
        public int NewsId { get; set; }
        public  string ImageUrl { get; set; }

        public string status { get; set; }
    }
}
