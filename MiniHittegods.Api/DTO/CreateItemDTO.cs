using System.ComponentModel.DataAnnotations;

namespace MiniHittegods.Api.DTO;

public class CreateItemDto
{
    [Required]
    [MaxLength(80)]
    public required string Title { get; set; }

    [Required]
    public required string FoundLocation { get; set; }

    public string? Category { get; set; }
}
