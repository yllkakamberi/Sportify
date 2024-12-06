using Microsoft.AspNetCore.Mvc;
using Sportify.Entities;

namespace Sportify.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Tennis Racket",
                Description = "A high-quality tennis racket",
                Price = 150.99m,
                PictureUrl = "http://example.com/tennis-racket.png",
                ProductTypeId = 1,
                ProductBrandId = 1,
                ProductType = new ProductType
                {
                    Id = 1,
                    Name = "Sports Equipment"
                },
                ProductBrand = new ProductBrand
                {
                    Id = 1,
                    Name = "Babolat"
                }
            },
            new Product
            {
                Id = 2,
                Name = "Running Shoes",
                Description = "Comfortable running shoes",
                Price = 85.50m,
                PictureUrl = "http://example.com/running-shoes.png",
                ProductTypeId = 2,
                ProductBrandId = 2,
                ProductType = new ProductType
                {
                    Id = 2,
                    Name = "Footwear"
                },
                ProductBrand = new ProductBrand
                {
                    Id = 2,
                    Name = "Nike"
                }
            },
            new Product
            {
                Id = 3,
                Name = "Pro Tennis Racket",
                Description = "A premium tennis racket used by professionals.",
                Price = 250.00m,
                PictureUrl = "http://example.com/pro-tennis-racket.png",
                ProductTypeId = 1,
                ProductBrandId = 1,
                ProductType = new ProductType
                {
                    Id = 1,
                    Name = "Sports Equipment"
                },
                ProductBrand = new ProductBrand
                {
                    Id = 1,
                    Name = "Wilson"
                }
            },
            new Product
            {
                Id = 4,
                Name = "Speedster Running Shoes",
                Description = "Lightweight running shoes designed for speed.",
                Price = 120.75m,
                PictureUrl = "http://example.com/speedster-running-shoes.png",
                ProductTypeId = 2,
                ProductBrandId = 2,
                ProductType = new ProductType
                {
                    Id = 2,
                    Name = "Footwear"
                },
                ProductBrand = new ProductBrand
                {
                    Id = 2,
                    Name = "Nike"
                }
            },
            new Product
            {
                Id = 5,
                Name = "Tennis Jersey",
                Description = "Comfortable tennis jersey for optimal performance.",
                Price = 45.00m,
                PictureUrl = "http://example.com/tennis-jersey.png",
                ProductTypeId = 3,
                ProductBrandId = 3,
                ProductType = new ProductType
                {
                    Id = 3,
                    Name = "Apparel"
                },
                ProductBrand = new ProductBrand
                {
                    Id = 3,
                    Name = "Adidas"
                }
            },
            new Product
            {
                Id = 6,
                Name = "Sports Jersey",
                Description = "Breathable sports jersey, perfect for any sport.",
                Price = 50.00m,
                PictureUrl = "http://example.com/sports-jersey.png",
                ProductTypeId = 3,
                ProductBrandId = 4,
                ProductType = new ProductType
                {
                    Id = 3,
                    Name = "Apparel"
                },
                ProductBrand = new ProductBrand
                {
                    Id = 4,
                    Name = "Puma"
                }
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_products);
        }

        // GET: api/v1/products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product newProduct)
        {
            newProduct.Id = _products.Max(p => p.Id) + 1;
            _products.Add(newProduct);

            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/v1/products/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(
            int id,
            [FromBody] Product updateProduct
        )
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

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
            product.ProductType = updateProduct.ProductType;
            product.ProductBrand = updateProduct.ProductBrand;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);

            return NoContent();
        }

    }

}
