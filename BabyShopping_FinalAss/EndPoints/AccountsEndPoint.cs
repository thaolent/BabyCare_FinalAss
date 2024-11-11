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
    // private static readonly List <AccountsDTO> accounts = [
    //                     new (1, "thaolent", "12345678", "thanhthao110889@gmail.com", "0982345167",0,1),
    //                     new (2, "nicemole", "12345679", "testdulux1@gmail.com", "0982345168",1,1)
    // ];

    const string GetAccountEndPoint = "GetAccount";
    public static RouteGroupBuilder MapAccountEndpoint (this WebApplication app)
    {
        var group = app.MapGroup("accounts");

        group.MapGet("/", async (BabyCareContext dbContext)=> 
                await dbContext.Accounts
                                .Select(acc =>acc.toDTO())
                                .AsNoTracking()
                                .ToListAsync());
        
        

        //get account with username
        app.MapGet("/{userName}", async (string userName, BabyCareContext dbContext)=>
        {
            Accounts? account = await dbContext.Accounts.FindAsync(userName);

            return account is null ? 
                Results.NotFound() : Results.Ok(account.toDTO());
        }
        ).WithName(GetAccountEndPoint);

        //POST account
        group.MapPost("/{accountType}",async (int accountType, CreateAccountDTO newacc, BabyCareContext dbContext) => 
        {
            // get max id
            Accounts? account = dbContext.Accounts.OrderByDescending(acc => acc.AccountId).FirstOrDefault();
            //find account type
            Accounts? accType = dbContext.Accounts.Where(acc => acc.Username.Equals(newacc.UserName)).FirstOrDefault();
            // username existing
            if (accType != null) {
                return Results.BadRequest();
            } else {
                int accountID = account is null ? 1 : account.AccountId + 1;
                Accounts acc = newacc.ToEntity();
             // insert new product
                dbContext.Accounts.Add(acc);
                await dbContext.SaveChangesAsync();
                return Results.CreatedAtRoute(GetAccountEndPoint, new {userName = accountID}, acc.toDTO());
            }
            //return Results.NotFound();
            
        });

        //Put accounts
        group.MapPut ("/{_accountId}", async (int _accountId, UpdateAccountDTO updateAccount, BabyCareContext dbContext) => 
        {
            var existingAcc = await dbContext.Accounts.FindAsync(_accountId);

            if (existingAcc is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingAcc)
                     .CurrentValues
                     .SetValues(updateAccount.ToEntity(_accountId));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();

        }
        );

        //Delete accounts
        // app.MapDelete("accounts/{Account_id}", (int Account_id) =>
        // {
        //     accounts.RemoveAll(accounts=>accounts.AccountId == Account_id);
        //     return Results.NoContent();
        // }
        // );
        // return app;
        return group;

    }

}
