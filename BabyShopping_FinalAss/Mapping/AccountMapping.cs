using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;

namespace BabyShopping_FinalAss.Mapping
{
    public static class AccountMapping
    {
        public static Accounts ToEntity (this CreateAccountDTO _acc)
        {
            if (_acc.AccountType.Equals(1))
            {
                return new Accounts()
                {
                    Username = _acc.UserName,
                    Email = _acc.Email,
                    Password = _acc.Password,
                    Phone = _acc.Phone,
                    AccountType = _acc.AccountType,
                    Status = _acc.Status
                };

            }
            return (Accounts)Results.NotFound();
        }

        public static AccountsDTO toDTO (this Accounts _acc)
        {
            return new AccountsDTO(_acc.AccountId, _acc.Username, _acc.Email, _acc.Password, _acc.Phone, _acc.AccountType, _acc.Status);
                
        }
        
    }
}