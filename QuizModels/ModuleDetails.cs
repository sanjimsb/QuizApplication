using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizModels;
public class ModuleDetails
{
    [Key]
    [Required]
    public int? Id { get; set; }

    [ForeignKey("Module")]
    public int? ModuleId { get; set; }

    [ForeignKey("User")]
    public string? UserId { get; set; }

    public int? MarksObtained { get; set; }

}