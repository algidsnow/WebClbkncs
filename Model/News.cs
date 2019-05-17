using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Title must be between 10 and 50 char", MinimumLength = 10)]
        public string Title { get; set; }
        [MaxLength()]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public string UrlRepresent { get; set; }

        public int status { get; set; }
        public int prioritize { get; set; }
    }
}
