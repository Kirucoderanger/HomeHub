namespace HomeHub.Models;

public class PropertyFavorite
{
    public int PropertyId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Property Property { get; set; } = null!;
}
