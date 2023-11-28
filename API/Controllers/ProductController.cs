using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Request;
using API.Response;
using AutoMapper;
using Data;
using Data.Model;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductData _productData;
        private IProductDomain _productDomain;
        private IMaintenanceData _maintenanceData;
        private IMaintenanceActivityDomain _maintenanceActivityDomain;
        private IMapper _mapper;
        
        
        public ProductController(IProductData productData, IProductDomain productDomain, IMapper mapper, IMaintenanceActivityDomain maintenanceActivityDomain,IMaintenanceData maintenanceData)
        {
            _productData = productData;
            _productDomain = productDomain;
            _maintenanceData = maintenanceData;
            _maintenanceActivityDomain = maintenanceActivityDomain;
            _mapper = mapper;
        }
        
        // GET: api/Product
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return _productData.getById(id);
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<ProductResponse> Post([FromBody] ProductRequest productRequest)
        {
            var product = _mapper.Map<ProductRequest, Product>(productRequest);
            if (_productDomain.create(product))
            {
                return _mapper.Map<Product, ProductResponse>(product);
            }

            return StatusCode(404);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
