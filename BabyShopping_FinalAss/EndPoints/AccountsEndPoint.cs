using System;
using System.Security.Cryptography.X509Certificates;
using BabyShopping_FinalAss.Data;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;
using BabyShopping_FinalAss.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BabyShopping_FinalAss.EndPoints;

public static class AccountsEndPoint
{
    private static readonly List <AccountsDTO> accounts = [
                        new (1, "thaolent", "12345678", "thanhthao110889@gmail.com", "0982345167",0,1),
                        new (2, "nicemole", "12345679", "testdulux1@gmail.com", "0982345168",1,1)
    ];

    const string GetAccountEndPoint = "Get Account";
    public static WebApplication MapAccountEndpoint (this WebApplication app)
    {
        var group = app.MapGroup("accounts");

        app.MapGet("/", async (BabyCareContext dbContext)=> 
                await dbContext.Accounts
                                .Select(acc =>acc.toDTO())
                                .AsNoTracking()
                                .ToListAsync());

        //get products = 1
        app.MapGet("/{accountId}",async (int accountId, BabyCareContext dbContext)=>
        {
            Accounts? account = await dbContext.Accounts.FindAsync(accountId);

            return group;
        }
        ).WithName(GetAccountEndPoint);

        //POST account
        app.MapPost("accounts/_accounType",(CreateAccountDTO newacc, BabyCareContext dbContext) => 
        {
            // get max id
            Accounts? account = dbContext.Accounts.OrderByDescending(acc => acc.AccountId).FirstOrDefault();
            //find account type
            Accounts? accType = dbContext.Accounts.Find(newacc.AccountType);
            int accountID;
            if (accType!=null && accType.Equals(1))
            {
                accountID = account is null ? 1 : account.AccountId + 1;
                Accounts accs = new Accounts() {
                    AccountId = accountID, 
                    Username = newacc.UserName,
                    Email = newacc.Email,
                    Password = newacc.Password,
                    Phone = newacc.Phone,
                    AccountType = newacc.AccountType,
                    Status = newacc.Status
                };
             // insert new product
                dbContext.Accounts.Add(accs);
                dbContext.SaveChanges();
                return Results.CreatedAtRoute(GetAccountEndPoint, new {id = accountID}, accs);
            }
            return Results.NotFound();
            
        }).WithName(GetAccountEndPoint);

        //Put accounts
        // app.MapPut ("accounts/{_accountId}", (int _accountId, UpdateAccountDTO updateAccount) => 
        // {
        //     var index = accounts.FindIndex(accounts => accounts.AccountId == _accountId);

        //     if (index ==-1)
        //     {
        //         return Results.NotFound();
        //     }

        //     // AccountsDTO updateAccountDTO = accounts[index];
        //     // updateAccountDTO.Email(updateAccount.Email);

        //     var updateAcc = accounts[index];
        //     updateAcc.Email = updateAccount.Email;

                
        //     return Results.NoContent();

        // }
        // );

        //Delete accounts
        app.MapDelete("accounts/{Account_id}", (int Account_id) =>
        {
            accounts.RemoveAll(accounts=>accounts.AccountId == Account_id);
            return Results.NoContent();
        }
        );
        return app;

    }

}
