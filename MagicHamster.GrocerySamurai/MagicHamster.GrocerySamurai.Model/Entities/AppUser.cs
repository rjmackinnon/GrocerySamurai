using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.Model.Entities
{
    [Table("app_user")]
    public class AppUser : Entity
    {
        [Column("username")]
        [MaxLength(45)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Column("password")]
        [MaxLength(45)]
        public string Password { get; set; }

        [Column("firstname")]
        [MaxLength(45)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Column("lastname")]
        [MaxLength(45)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Column("email")]
        [MaxLength(45)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Column("address")]
        [MaxLength(45)]
        public string Address { get; set; }

        [Column("phone")]
        [MaxLength(45)]
        public int Phone { get; set; }
    }
}
