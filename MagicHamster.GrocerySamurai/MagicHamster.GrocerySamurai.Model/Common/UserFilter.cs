namespace MagicHamster.GrocerySamurai.Model.Common
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class UserFilter : Entity
    {
        [Column("user_id")]
        [Required]
        public string UserId { get; set; }
    }
}
