using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.Entities;

namespace BabyShopping_FinalAss.Mapping
{
    public static class RatingMapping
    {
        public static Ratings ToEntity(this CreateRatings _rates)
        {
            return new Ratings()
            {
                ProductId = _rates.RefProductId,
                Comment = _rates.Comment,
                Point = _rates.Point
            };
        }

        public static Ratings ToEntity (this UpdateRatingDTO _updateRate, int _rateId)
        {
            return new Ratings()
            {
                RatingId = _rateId,
                ProductId = _updateRate.RefProductId,
                Comment = _updateRate.Comment,
                Point = _updateRate.Point
            };
        }

        public static RatingSumaryDTO toRateSummaryDto (this Ratings rates)
        {
            return new (
                rates.RatingId,
                rates.ProductId,
                rates.Comment,
                rates.Point
            );
        }
        
    }
}