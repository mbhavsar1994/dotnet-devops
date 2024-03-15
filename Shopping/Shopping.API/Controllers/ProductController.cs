using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController
	{
		private readonly ILogger<ProductController> _logger;

		private readonly ProductContext _productContext;

		public ProductController(ProductContext productContext, ILogger<ProductController> logger)
		{
			_productContext = productContext ?? throw new ArgumentNullException(nameof(ProductContext));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		public async Task<IEnumerable<Product>> Get()
		{
		   return await _productContext.Products
					.Find(x => true).ToListAsync();
		}
	}
}

