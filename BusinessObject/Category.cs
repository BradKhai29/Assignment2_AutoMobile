using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Category", Schema = "dbo")]
    public class Category
    {
        #region Property
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^([a-zA-Z]+[\\s]*)+$", ErrorMessage = nameof(CategoryName))]
        public string CategoryName { get; set; }
        #endregion

        #region Relationships
        public ICollection<Product> Products { get; set; }
        #endregion
    }
}
