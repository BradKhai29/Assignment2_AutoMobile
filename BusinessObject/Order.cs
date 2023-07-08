using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Order", Schema = "dbo")]
    public class Order
    {
        #region Property
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Freight { get; set; }

        [NotMapped]
        public decimal TotalAmount { get; set; }
        #endregion

        #region Relationships
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }

        public ICollection<OrderDetail> Details { get; set; }
        #endregion
    }
}
