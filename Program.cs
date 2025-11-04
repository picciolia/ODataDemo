using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;
using Microsoft.EntityFrameworkCore;
using ODataDemo.Data;
using ODataDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// EF in-memory per la demo
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ODataDemoDb"));

builder.Services
    .AddControllers()
    .AddOData(opt =>
        opt.EnableQueryFeatures()           // abilita $filter, $select, ...
           .AddRouteComponents("odata", GetEdmModel())
           .Select()
           .Filter()
           .OrderBy()
           .Expand()
           .SetMaxTop(100)
           .Count()
    );

var app = builder.Build();

// Seed dati
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Categories.Any())
    {
        var cat1 = new Category { Title = "Hardware" };
        var cat2 = new Category { Title = "Software" };
        db.Categories.AddRange(cat1, cat2);

        db.Products.AddRange(
            new Product { Name = "Mouse", Price = 19.99m, Category = cat1 },
            new Product { Name = "Tastiera", Price = 49.90m, Category = cat1 },
            new Product { Name = "IDE Pro", Price = 199.00m, Category = cat2 }
        );
        db.SaveChanges();
    }
}

app.MapControllers();
app.Run();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    builder.EntitySet<Category>("Categories");
    return builder.GetEdmModel();
}
