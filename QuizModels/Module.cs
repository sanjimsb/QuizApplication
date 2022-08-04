using System.ComponentModel.DataAnnotations;

namespace QuizModels;
public class Module
{
    [Key]
    [Required]
    public int? Id { get; set; }

    [Required]
    public string? ModuleName { get; set; }

    public string? Description { get; set; }

    [Required]
    public bool NegativeMarking { get; set; }

    [Required]
    public bool Timed { get; set; }

    public int Time { get; set; }

}