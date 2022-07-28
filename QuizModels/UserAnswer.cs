using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizModels;
public class UserAnswer
{
    [Key]
    public string? Id { get; set; }

    [ForeignKey("Quize")]
    public string? QuizId { get; set; }

    [ForeignKey("User")]
    public string? UserId { get; set; }

    [Required]
    public string? Answer { get; set; }
}