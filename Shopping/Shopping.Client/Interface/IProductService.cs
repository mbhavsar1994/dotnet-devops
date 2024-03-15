using System;
using Shopping.Client.Models;

namespace Shopping.Client.Interface
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetProducts();
	}
}

