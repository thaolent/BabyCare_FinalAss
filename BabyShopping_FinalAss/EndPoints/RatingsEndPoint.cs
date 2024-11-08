using System;
using BabyShopping_FinalAss.Data;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;
using BabyShopping_FinalAss.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BabyShopping_FinalAss.EndPoints;

public static class RatingsEndPoint
{
    // private static readonly List <RatingsDTO> ratings = [
    //                 new (1, 1, "This is rating for product 1",5),
    //                 new (2,  6, "This is rating for product 6", 7),
    //                 new (3, 11, "This iss rating for product 11", 8)
    // ];
    const string GetRatingEndPointName = "GetRating";
    public  static RouteGroupBuilder MapRatingsEndPoint (this WebApplication app)
    {
        var group = app.MapGroup("ratings");

        group.MapGet("/", async (BabyCareContext dbContext) => 
            await dbContext.Ratings
                     .Include(rating => rating.Product)
                     .Select(rating => rating.toRateSummaryDto())
                     .AsNoTracking()
                     .ToListAsync());

        //get ratings with id = 1
        group.MapGet("/{ratingId}", async (int ratingId, BabyCareContext babyCareContext)=>
        {
            Ratings? ratings = await babyCareContext.Ratings.FindAsync(ratingId);

            return ratings is null ? 
                Results.NotFound() : Results.Ok(ratings.toRateSummaryDto());
        }
        ).WithName(GetRatingEndPointName);

        //POST Ratings
        group.MapPost("/",async(CreateRatings newrate, BabyCareContext dbContext)=> 
        {

            // get max id
            Ratings? ratingEntity = dbContext.Ratings.OrderByDescending(rating => rating.RatingId).FirstOrDefault();
            // next id = max id + 1
            int ratingID = ratingEntity is null ? 1 : ratingEntity.RatingId + 1;
            // find product
            Products? product = dbContext.Products.Find(newrate.RefProductId);
            // return error
            if(product is null) {
                return Results.NotFound();
            }
            
            Ratings _rate = newrate.ToEntity();
            // insert new product
            dbContext.Ratings.Add(_rate);
            await dbContext.SaveChangesAsync();
            return Results.CreatedAtRoute(GetRatingEndPointName, new {id = ratingID}, _rate.toRateSummaryDto());

        });

        //Put Rating
        group.MapPut ("/{_ratingId}",async (int _ratingId, UpdateRatingDTO updatedRate, BabyCareContext dbContext) =>
        {
                var existingRate = await dbContext.Ratings.FindAsync(_ratingId);
                if (existingRate is null)
                {
                    return Results.NotFound();
                }
                dbContext.Entry(existingRate)
                     .CurrentValues
                     .SetValues(updatedRate.ToEntity(_ratingId));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
        }
        );

        //Delete rating
        group.MapDelete("/{Rate_Id}", async (int _rateid, BabyCareContext dbContext) =>
        {
            await dbContext.Ratings
                     .Where(rate => rate.RatingId == _rateid)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        }
        );
        return group;
    }

}
