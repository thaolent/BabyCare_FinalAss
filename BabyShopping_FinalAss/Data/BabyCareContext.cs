using BabyShopping_FinalAss.Entities;
using Microsoft.EntityFrameworkCore;

namespace BabyShopping_FinalAss.Data;

public class BabyCareContext(DbContextOptions<BabyCareContext> options) : DbContext(options)
{
    public DbSet<Categories> Categories => Set<Categories>();
    public DbSet<Products> Products => Set<Products>();
    public DbSet<Ratings> Ratings => Set<Ratings>();
    public DbSet<Accounts> Accounts => Set<Accounts>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Categories>().HasData(
            new {CategoryId= 1, CategoryName = "Diapers", Description = "Diaper for infant and baby"},
            new {CategoryId= 2, CategoryName = "Powdered Milk", Description = "A dairy product made by evaporating milk to dryness"},
            new {CategoryId= 3, CategoryName = "Reconstituted milk", Description = "Mixing milk powder with water to create liquid milk"},
            new {CategoryId= 4, CategoryName = "Baby Food", Description = "This food is specifically made to meet the nutritional needs of infants and toddlers, ensuring they get the essential vitamins and minerals for proper growth and development"},
            new {CategoryId= 5, CategoryName = "Vitamins", Description = " vitamins are essential for their growth and development"}
        );

        modelBuilder.Entity<Products>().HasData(
            new{ProductId = 1, ProductName = "Huggies Nature Made", CategoryId = 1, Description = "Platinum", AveragePoint = 7.5m, Price = 195000.0m, Image = @"D:\.NET\BabyShopping_Image\Diaper\Huggies.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 2, ProductName = "Bobby", CategoryId = 1, Description = "Bobby for baby", AveragePoint = 5.0m, Price = 189900.0m, Image = @"D:\.NET\BabyShopping_Image\Diaper\bobby.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin" },
            new {ProductId = 3, ProductName = "Gooby", CategoryId = 1, Description = "Gooby Extra Newborn Little ", AveragePoint = 9.0m, Price = 205000.0m, Image = @"D:\.NET\BabyShopping_Image\Diaper\gooby.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 4, ProductName = "Nabizam", CategoryId = 1, Description = "Bland, soft fabric. - Ultra-soft fabric using the super-microfiber ", AveragePoint = 7.2m, Price = 234098.0m, Image = @"D:\.NET\BabyShopping_Image\Diaper\nabizam.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 5, ProductName = "Mamogom", CategoryId = 1, Description = "MAMOGOM Premium CARE ORGANIC KOREAN PREMIUM CARE  ", AveragePoint = 6.1m, Price = 245000.0m, Image = @"D:\.NET\BabyShopping_Image\Diaper\mamogom.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
        
            new{ProductId = 6, ProductName = "Aptamil", CategoryId = 2, Description = "Aptamil NewZeland", AveragePoint = 7.5m, Price = 195000.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Powdered milk\aptamil_bac.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 7, ProductName = "Blackmores", CategoryId = 2, Description = "For infant", AveragePoint = 5.0m, Price = 189900.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Powdered milk\blackmore.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin" },
            new {ProductId = 8, ProductName = "ColosBaby", CategoryId = 2, Description = "Colos for baby", AveragePoint = 9.0m, Price = 205000.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Powdered milk\colosbaby.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 9, ProductName = "Enfamil A+", CategoryId = 2, Description = "Well-cooked, pureed legumes such as beans, lentils and chickpeas.", AveragePoint = 7.2m, Price = 234098.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Powdered milk\enfamil.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 10, ProductName = "HiPP", CategoryId = 2, Description = "HiPP becomes Germany's third company and first food manufacturer", AveragePoint = 6.1m, Price = 245000.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Powdered milk\hipp.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},

            new{ProductId = 11, ProductName = "Abott Grow", CategoryId = 3, Description = "Abott Grow", AveragePoint = 7.5m, Price = 195000.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Liquid milk\abottgrow.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 12, ProductName = "Aptakid", CategoryId = 3, Description = "Aptakid", AveragePoint = 5.6m, Price = 189900.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Liquid milk\aptakid.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin" },
            new {ProductId = 13, ProductName = "ColosBaby", CategoryId = 3, Description = "Colos for baby", AveragePoint = 4.0m, Price = 205000.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Liquid milk\colosbaby.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 14, ProductName = "DalatMilk", CategoryId = 3, Description = "DalatMilk", AveragePoint = 7.4m, Price = 123000.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Liquid milk\dalatmilk.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 15, ProductName = "Vinamilk", CategoryId = 3, Description = "Vinamil Green farm", AveragePoint = 9.8m, Price = 134000.0m, Image = @"D:\.NET\BabyShopping_Image\Milk\Liquid milk\vinamilk xanh.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},

            new{ProductId = 16, ProductName = "Gerber Puffs", CategoryId = 4, Description = "Banh an dam", AveragePoint = 7.5m, Price = 195000.0m, Image = @"D:\.NET\BabyShopping_Image\Baby Food\banhandamGerber.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 17, ProductName = "BioKids", CategoryId = 4, Description = "Bot an dam vi lua mach", AveragePoint = 5.6m, Price = 189900.0m, Image = @"D:\.NET\BabyShopping_Image\Baby Food\botbiokid.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin" },
            new {ProductId = 18, ProductName = "Bot Heinz", CategoryId = 4, Description = "Bot an dam vij sua", AveragePoint = 4.0m, Price = 205000.0m, Image = @"D:\.NET\BabyShopping_Image\Baby Food\botHeinz.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 19, ProductName = "Bot HiPP Organic", CategoryId = 4, Description = "Bot an dam Hipp", AveragePoint = 7.4m, Price = 123000.0m, Image = @"D:\.NET\BabyShopping_Image\Baby Food\botHipp.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 20, ProductName = "Vang sua Hoff", CategoryId = 4, Description = "Vang sua trai cay", AveragePoint = 9.8m, Price = 134000.0m, Image = @"D:\.NET\BabyShopping_Image\Baby Food\vangsuahoff.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},

            new{ProductId = 21, ProductName = "BioGaia", CategoryId = 5, Description = "Men tieu hoa", AveragePoint = 7.5m, Price = 195000.0m, Image = @"D:\.NET\BabyShopping_Image\Vitamin\biogaia.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 22, ProductName = "Sunday Natural", CategoryId = 5, Description = "D3K2", AveragePoint = 5.6m, Price = 189900.0m, Image = @"D:\.NET\BabyShopping_Image\Vitamin\sunday natural.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin" },
            new {ProductId = 23, ProductName = "Fitobimbi", CategoryId = 5, Description = "An ngon ngu ngon", AveragePoint = 4.0m, Price = 205000.0m, Image = @"D:\.NET\BabyShopping_Image\Vitamin\fitobimbi.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 24, ProductName = "PediaKid", CategoryId = 5, Description = "MultiVitamins", AveragePoint = 7.4m, Price = 123000.0m, Image = @"D:\.NET\BabyShopping_Image\Vitamin\pediakid.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"},
            new {ProductId = 25, ProductName = "Kid Smart drops", CategoryId = 5, Description = "Probiotic", AveragePoint = 9.8m, Price = 134000.0m, Image = @"D:\.NET\BabyShopping_Image\Vitamin\pribiotic.jpg", CreatedDate = DateTime.Now, CreatedBy = "Admin", UpdatedDate = DateTime.Now, UpdatedBy = "Admin"}
        );

        modelBuilder.Entity<Accounts>().HasData(
            new{AccountId = 1, Username = "thaolent", Password = "12345678", Email = "thanhthao110889@gmail.com", Phone = "0982345167", AccountType = 0, Status = 1},
            new{AccountId = 2, Username = "dungdq", Password = "12345678", Email = "kisshoang@gmail.com", Phone = "0982345168", AccountType = 1, Status = 1},
            new{AccountId = 3, Username = "customer1", Password = "12345678", Email = "testdulux1@gmail.com", Phone = "0982345168", AccountType = 1, Status = 1},
            new{AccountId = 4, Username = "customer2", Password = "12345678", Email = "testdulux2@gmail.com", Phone = "0982345168", AccountType = 1, Status = 1},
            new{AccountId = 5, Username = "customer3", Password = "12345678", Email = "testdulux3@gmail.com", Phone = "0982345168", AccountType = 1, Status = 1}
        );

        modelBuilder.Entity<Ratings>().HasData(
            new {RatingId = 1, ProductId = 1, Comment = "This iss rating for product 1", Point = 5},
            new {RatingId = 2, ProductId = 6, Comment = "This iss rating for product 6", Point = 7},
            new {RatingId = 3, ProductId = 10, Comment = "This iss rating for product 10", Point = 8},
            new {RatingId = 4, ProductId = 19, Comment = "This iss rating for product 19", Point = 6},
            new {RatingId = 5, ProductId = 22, Comment = "This iss rating for product 22", Point = 9}
        );

    }

}
