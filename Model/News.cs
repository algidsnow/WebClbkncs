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
        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Title must be between 10 and 50 char", MinimumLength = 10)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }
        public int prioritize { get; set; }
    }
}
