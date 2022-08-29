using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CG_VAK_BooksWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,100, ErrorMessage="The order display value should be in the range of 1 to 100")]
        [DisplayName("Order of Display")]
        public  int?  OrderOfDisplay { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
