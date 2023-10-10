#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Guest
{
    [Key]
    public int GuestId { get; set; }
    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }
    [Required]
    public int WeddingId { get; set; }
    public Wedding? Wedding { get; set; }

    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}