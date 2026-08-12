using System.ComponentModel.DataAnnotations;

namespace HomeHub.Models;

public class Property
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(100)]
    public string Region { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string PropertyType { get; set; } = "House";

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = "For Sale";

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, 100)]
    public int Bedrooms { get; set; }

    [Range(0, 100)]
    public int Bathrooms { get; set; }

    [Range(0, double.MaxValue)]
    public decimal AreaSqm { get; set; }

    [Required]
    public string OwnerId { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();

    public ICollection<PropertyFavorite> Favorites { get; set; } =
        new List<PropertyFavorite>();
}
