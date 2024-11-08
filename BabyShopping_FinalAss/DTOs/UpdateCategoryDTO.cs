using System.ComponentModel.DataAnnotations;

namespace BabyShopping_FinalAss.DTOs;

public record class UpdateCategoryDTO (
    [Required][StringLength(50)]string CategoryName, 
    string Description);
