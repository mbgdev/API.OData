using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData.WebAPI.Models;
 

    ODataConventionModelBuilder odataBuilder = new();

    odataBuilder.EntitySet<Category>("Categories");
    odataBuilder.EntitySet<Product>("Products");


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(options =>
{
    options.AddRouteComponents("odata", odataBuilder.GetEdmModel());
    options.Select().Expand().OrderBy().Filter().SetMaxTop(null).SkipToken();
    
    

});



builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
