#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace QuestLogs.Models;

public class UserQuest
{
    [Key]
    public int UserQuestId { get; set; }
    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }
    [Required]
    public int QuestId { get; set; }
    public Quest? Quest { get; set; }
    [Required]
    public bool completed { get; set; } = false;
    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}