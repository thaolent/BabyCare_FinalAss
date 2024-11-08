
namespace BabyShopping_FinalAss.DTOs;

public record class AccountsDTO(int AccountId, string UserName, string Email, string Password, string Phone, int AccountType, int Status);
//Account type: 0: admin, 1: custmer
//Status: 0: disable, 1: enable

