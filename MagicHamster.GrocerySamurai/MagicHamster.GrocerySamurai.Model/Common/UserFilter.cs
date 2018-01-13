using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicHamster.GrocerySamurai.Model.Common
{
    public abstract class UserFilter : Entity
    {
        [Column("user_id")]
        [Required]
        public string UserId { get; set; }
    }
}
