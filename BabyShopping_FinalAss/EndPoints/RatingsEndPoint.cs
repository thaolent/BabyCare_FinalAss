using System;
using BabyShopping_FinalAss.Data;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;

namespace BabyShopping_FinalAss.EndPoints;

public static class RatingsEndPoint
{
    private static readonly List <RatingsDTO> ratings = [
                    new (1, 1, "This is rating for product 1",5),
                    new (2,  6, "This is rating for product 6", 7),
                    new (3, 11, "This iss rating for product 11", 8)
    ];
    const string GetRatingEndPointName = "Get Rating";
    public  static RouteGroupBuilder MapRatingsEndPoint (this WebApplication app)
    {
        var group = app.MapGroup("ratings");
        
        group.MapGet("/",()=>ratings);
        //get ratings with id = 1
        group.MapGet("/{ratingId}",(int ratingId)=> 
        {
            RatingsDTO? rate = ratings.Find(ratings =>ratings.RatingId == ratingId);
            return rate is null ? Results.NotFound(): Results.Ok(rate);
        }
        ).WithName(GetRatingEndPointName);

        //POST Ratings
        group.MapPost("/",(CreateRatings newrate, BabyCareContext dbContext) => 
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
            Ratings rate = new Ratings {
                RatingId = ratingID, 
                RefProductId = product,
                Comment = newrate.Comment,
                Point = newrate.Point
            };
            // insert new product
            dbContext.Ratings.Add(rate);
            dbContext.SaveChanges();
            return Results.CreatedAtRoute(GetRatingEndPointName, new {id = ratingID}, rate);

        }).WithName(GetRatingEndPointName);

        //Put Rating
        group.MapPut ("/{_ratingId}",(int _ratingId, UpdateRatingDTO updateRate)=>
        {
                var index = ratings.FindIndex(ratings =>ratings.RatingId == _ratingId);
                if (index ==-1)
                {
                    return Results.NotFound();
                }
                ratings[index] = new RatingsDTO
                (
                    _ratingId,
                    updateRate.RefProductId.ProductId,
                    updateRate.Comment,
                    updateRate.Point
                );

                return Results.NoContent();

        }
        );

        //Delete rating
        group.MapDelete("/{Rate_Id}", (int Rate_Id) =>
        {
            ratings.RemoveAll(ratings=>ratings.RatingId == Rate_Id);
            return Results.NoContent();
        }
        );

        return group;
    }

}
