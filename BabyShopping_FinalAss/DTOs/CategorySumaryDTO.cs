using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyShopping_FinalAss.DTOs;
public record class CategorySumaryDTO(   
    int CategoryId,
    string CategoryName,
    string Description
    );
    
