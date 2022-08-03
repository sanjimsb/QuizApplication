using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizModels;
public class Quiz
{
    [Key]
    [Required]
    public int? Id { get; set; }

    [ForeignKey("Module")]
    public int? ModuleId { get; set; }

    [Required]
    public string? Question { get; set; }

    [Required]
    public string? QuestionType { get; set; }

    public string? Option1 { get; set; }

    public string? Option2 { get; set; }

    public string? Option3 { get; set; }

    public string? Option4 { get; set; }

    [Required]
    public string? CorrectAnswer { get; set; }
}