using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{
  public class Inventory
  {
    [Key]
    public Guid InventoryID { get; set; }

    [Required]
    [MaxLength(100,ErrorMessage ="Name can only be 100 characters long")]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int Price { get; set; }

    public string Department { get; set; }

    public string Balance { get; set; }

    public string UOM { get; set; }

    public int Units { get; set; }

    [TransDate]
    public DateTime Date { get; set; }
  }

  public class TransDateAttribute : ValidationAttribute
  {
    public TransDateAttribute() { }

    public string GetErrorMessage() => "User is not allowed to select Future Date";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var date = (DateTime)value;

      if (DateTime.Compare(date, DateTime.Now) > 0) return new ValidationResult(GetErrorMessage());
      else return ValidationResult.Success;
    }
  }
}
