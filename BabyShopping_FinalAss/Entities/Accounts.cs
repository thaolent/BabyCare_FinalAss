using System;
using System.ComponentModel.DataAnnotations;

namespace BabyShopping_FinalAss.Entities;

public class Accounts
{

    [Key]public int AccountId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Phone { get; set; }
    public int AccountType {get; set; } = 1;
    public int Status {get; set; } = 1;

}
