using BabyShopping_FinalAss.Data;
using BabyShopping_FinalAss.DTOs;
using BabyShopping_FinalAss.EndPoints;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("BabyCare");
builder.Services.AddSqlite<BabyCareContext>(connString);
builder.Services.AddDbContext<BabyCareContext>(options =>
    options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
var app = builder.Build();

app.MapProductsEndpoint();
app.MapCategoriesEndPoint();
app.MapRatingsEndPoint();
app.MapAccountEndpoint();

await app.MigrateDBAsync();

// const string GetProductEndPointName = "Get Product";
// const string GetCategoryEndPointName = "Get Category";
// const string GetRatingEndPointName = "Get Rating";



app.Run();





