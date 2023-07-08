using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        #region Property
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(40)]
        [RegularExpression("^([a-zA-Z]+[\\s]*)+$", ErrorMessage = "ProductName")]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = nameof(Weight))]
        public string Weight { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, int.MaxValue)]
        [RegularExpression("[0-9]+", ErrorMessage = nameof(UnitPrice))]
        public decimal UnitPrice { get; set; }

        [Range(1, int.MaxValue)]
        public int UnitsInStock { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;
        #endregion

        [NotMapped]
        public int OrderQuantity { get; set; } = 1;

        #region Relationships
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        #endregion
    }
}
