using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sessions_app.Models
{
    [Table("table_user_pb")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column("name_pb")]
        public string Name { get; set; } = "Sem Nome";
        [Column("email_pb")]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Column("password_pb")]
        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Column("status_active_pb")]
        public bool isActive { get; set; } = true;
        [Column("role_pb")]
        public string Role { get; set; } = "User";
        [Column("avatar_pb")]
        public string Avatar { get; set; } = "https://static.vecteezy.com/ti/vetor-gratis/p1/12749491-icone-de-meme-pikachu-surpreso-gratis-vetor.jpg";
    }
}
