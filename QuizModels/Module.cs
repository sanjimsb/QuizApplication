using System.ComponentModel.DataAnnotations;

namespace QuizModels;
public class Module
{
    [Key]
    public string? Id { get; set; }
    [Required]
    public string? ModuleName { get; set; }
}