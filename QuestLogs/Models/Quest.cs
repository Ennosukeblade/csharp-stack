#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace QuestLogs.Models;

public class Quest
{
    [Key]
    public int QuestId { get; set; }
    [Required]
    public int UserId { get; set; }
    public User? Creator { get; set; }
    [Required]
    [MinLength(3)]
    [Display(Name = "Quest Title")]
    public string Title { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    [Display(Name = "Reward Amount")]
    public int Reward { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "You need to be more descriptive!")]
    public string Description { get; set; }
    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    //* Users have joind me
    public List<UserQuest> joindUsers { get; set; } = new List<UserQuest>();

}