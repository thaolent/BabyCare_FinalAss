using System;
using System.ComponentModel.DataAnnotations;

namespace BabyShopping_FinalAss.Entities;

public class Categories
{
    [Key]public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public required string Description { get; set; }

}
