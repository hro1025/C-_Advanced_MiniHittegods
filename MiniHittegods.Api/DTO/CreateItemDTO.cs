using System.ComponentModel.DataAnnotations;

namespace MiniHittegods.Api.DTO;

public class CreateItemDto
{
    [Required]
    [MaxLength(80)]
    public string? Title { get; set; }

    [Required]
    public string? FoundLocation { get; set; }
}
