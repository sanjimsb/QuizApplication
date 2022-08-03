using System.ComponentModel.DataAnnotations;

namespace QuizModels;
public class Module
{
    [Key]
    [Required]
    public int? Id { get; set; }
    [Required]
    public string? ModuleName { get; set; }
}