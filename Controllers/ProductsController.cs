using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;
using ODataDemo.Data;
using ODataDemo.Models;
using Microsoft.AspNetCore.OData.Results;


namespace ODataDemo.Controllers;

public class ProductsController(AppDbContext db) : ODataController
{
    // GET /odata/Products
    [EnableQuery(PageSize = 20)]
    public IQueryable<Product> Get() => db.Products;

    // GET /odata/Products(1)
    [EnableQuery]
    public SingleResult<Product> Get([FromRoute] int key)
        => SingleResult.Create(db.Products.Where(p => p.Id == key));

    // POST /odata/Products
    public async Task<IActionResult> Post([FromBody] Product product)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return Created(product);
    }

    // PUT /odata/Products(1)
    public async Task<IActionResult> Put([FromRoute] int key, [FromBody] Product update)
    {
        if (key != update.Id) return BadRequest();
        db.Entry(update).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return Updated(update);
    }

    // PATCH /odata/Products(1)
    public async Task<IActionResult> Patch([FromRoute] int key, [FromBody] Delta<Product> delta)
    {
        var entity = await db.Products.FindAsync(key);
        if (entity is null) return NotFound();
        delta.Patch(entity);
        await db.SaveChangesAsync();
        return Updated(entity);
    }

    // DELETE /odata/Products(1)
    public async Task<IActionResult> Delete([FromRoute] int key)
    {
        var entity = await db.Products.FindAsync(key);
        if (entity is null) return NotFound();
        db.Products.Remove(entity);
        await db.SaveChangesAsync();
        return NoContent();
    }
}
