using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("OrderDetail", Schema = "dbo")]
    public class OrderDetail
    {
        #region Property
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        #endregion

        #region Relationships
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product PaidProduct { get; set; }
        #endregion
    }
}
