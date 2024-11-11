using System.ComponentModel.DataAnnotations;

namespace BabyShopping_FinalAss.DTOs;

public record class UpdateAccountDTO (
                [Required][StringLength(10)]string UserName, 
                [Required]string Email, 
                [Required]string Password, 
                [StringLength(10)]string Phone, 
                [Range(0,1)]int AccountType, 
                [Range(0,1)]int Status);