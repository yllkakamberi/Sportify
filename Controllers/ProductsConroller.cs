﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sportify.Data;
using Sportify.Entities;

namespace Sportify.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
       private readonly SportifyDbContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {

            var products = await _context.Products
                                           .Include(p => p.ProductType)
                                           .Include(p => p.ProductBrand)
                                           .ToListAsync();
                
            return Ok(products);
        }

        // GET: api/v1/products/{id}
        [HttpGet("{id}")]
        public async  Task< ActionResult<Product>> GetProductById(int id)
        {

            var product = await _context.Products
                                           .Include(p => p.ProductType)
                                           .Include(p => p.ProductBrand)
                                           .FirstOrDefaultAsync(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task< ActionResult<Product>> CreateProduct([FromBody] Product newProduct)
        {
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById),
                new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/v1/products/{id}
        [HttpPut("{id}")]
        public async Task <ActionResult>UpdateProduct(int id,
            [FromBody] Product updateProduct
        )
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            // Update product properties
            product.Name = updateProduct.Name;
            product.Description = updateProduct.Description;
            product.Price = updateProduct.Price;
            product.PictureUrl = updateProduct.PictureUrl;
            product.ProductTypeId = updateProduct.ProductTypeId;
            product.ProductBrandId = updateProduct.ProductBrandId;

            _context.Entry(product).State=EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}
