using System;
using System.Net.Http;
using Newtonsoft.Json;
using Shopping.Client.Controllers;
using Shopping.Client.Interface;
using Shopping.Client.Models;

namespace Shopping.Client.Services
{
    public class ProductService : IProductService
	{
        private readonly HttpClient _httpClient;

        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger,
                           IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient") ??
                                                        throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var response = await _httpClient.GetAsync("/product");

                var content = await response.Content.ReadAsStringAsync();

                var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

                return productList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Product API response error {ex.Message}");
                return new List<Product>();
            }

        }
    }
}

