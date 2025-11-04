using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

using ODataDemo.Data;
using ODataDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ODataDemo.Controllers;

public class CategoriesController(AppDbContext db) : ODataController
{
    [EnableQuery]
    public IQueryable<Category> Get() => db.Categories;

    [EnableQuery]
    public SingleResult<Category> Get([FromRoute] int key)
        => SingleResult.Create(db.Categories.Where(c => c.Id == key));
}
