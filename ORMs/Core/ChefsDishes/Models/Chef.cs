#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsDishes.Models;
public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    [Required]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1/1/1900", "1/1/2005")]
    [Display(Name = "Date of Birth")]
    // public DateOnly Birth { get; set; }
    public DateTime Birth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    //* Navigation Property
    public List<Dish> Dishes { get; set; } = new List<Dish>();

    // public static string Today(){
    //     return DateTime.Today.ToString();
    // }
}
