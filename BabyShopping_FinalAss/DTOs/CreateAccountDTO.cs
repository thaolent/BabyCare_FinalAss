using System.ComponentModel.DataAnnotations;

namespace BabyShopping_FinalAss.DTOs;

public record class CreateAccountDTO (
                [StringLength(20)]string UserName, 
                string Email, 
                string Password, 
                [StringLength(10)]string Phone, 
                [Range(0,1)]int AccountType, 
                [Range(0,1)]int Status
    );