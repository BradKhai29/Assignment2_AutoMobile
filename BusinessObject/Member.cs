using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Member", Schema = "dbo")]
    public class Member
    {
        #region Property
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z]+[0-9]*[.]?[a-zA-Z]+[0-9]*[@][a-zA-Z]+[0-9]*[.]?[a-zA-Z]+[0-9]*$", ErrorMessage = nameof(Email))]
        public string Email { get; set; }

        [Required]
        [MaxLength(40)]
        [RegularExpression("^([a-zA-Z]+[\\s]*)+$", ErrorMessage = nameof(CompanyName))]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(15)]
        [RegularExpression("^([a-zA-Z]+[\\s]*)+$", ErrorMessage = nameof(City))]
        public string City { get; set; }

        [Required]
        [MaxLength(15)]
        [RegularExpression("^([a-zA-Z]+[\\s]*)+$", ErrorMessage = nameof(Country))]
        public string Country { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        #endregion

        #region Relationships
        public ICollection<Order> Orders { get; set; }
        #endregion
    }
}
