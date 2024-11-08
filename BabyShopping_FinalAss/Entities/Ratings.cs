using System;
using System.ComponentModel.DataAnnotations;

namespace BabyShopping_FinalAss.Entities;

public class Ratings
{
    [Key]public int RatingId { get; set; }

    public int ProductId {get; set;}
    public  Products? Product { get; set; }

    public required string Comment { get; set; }
    public int Point { get; set; }

}
