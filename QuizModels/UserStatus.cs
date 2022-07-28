using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizModels;
public class UserStatus
{
    [Key]
    public string? Id { get; set; }

    [ForeignKey("User")]
    public string? UserId { get; set; }

    [Required]
    public string? Status { get; set; }
}