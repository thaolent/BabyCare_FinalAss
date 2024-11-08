using System.ComponentModel.DataAnnotations;
using BabyShopping_FinalAss.Entities;

namespace BabyShopping_FinalAss.DTOs;

public record class UpdateRatingDTO (
    [Required]int RefProductId, 
    [Required]string Comment, 
    [Range(1,10)]int Point);
