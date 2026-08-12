using System.ComponentModel.DataAnnotations;

namespace HomeHub.Models;

public class PropertyImage
{
    public int Id { get; set; }

    public int PropertyId { get; set; }

    [Required]
    [StringLength(255)]
    public string FileName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string ContentType { get; set; } = string.Empty;

    public byte[] Data { get; set; } = Array.Empty<byte>();

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public Property Property { get; set; } = null!;
}
