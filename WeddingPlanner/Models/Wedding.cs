#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    [Required]
    public int UserId { get; set; }
    public User? Creator { get; set; }
    [Required]
    [MinLength(3)]
    [Display(Name = "Wedder One")]
    public string WedderOne { get; set; }
    [Required]
    [MinLength(3)]
    [Display(Name = "Wedder Two")]
    public string WedderTwo { get; set; }
    //[DataType(DataType.Date)]
    //[Range(typeof(DateTime), "1/1/1900", "1/1/2005")]
    [Required(ErrorMessage = "Date is required")]
    public DateTime Date { get; set; }
    [Required]
    [MinLength(8)]
    public string Address { get; set; }
    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    //* Users have joind wedding
    public List<Guest> Guests { get; set; } = new List<Guest>();

}