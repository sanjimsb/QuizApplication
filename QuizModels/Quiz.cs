using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizModels;
public class Quiz
{
    [Key]
    [Required]
    public int? Id { get; set; }

    [ForeignKey("Module")]
    public string? ModuleName { get; set; }

    [Required]
    public string? Question { get; set; }

    [Required]
    public string? Option1 { get; set; }

    [Required]
    public string? Option2 { get; set; }

    [Required]
    public string? Option3 { get; set; }

    [Required]
    public string? Option4 { get; set; }

    [Required]
    public string? CorrectAnswer { get; set; }
}