using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Product;
using Nothing.Models.Shop;
using Nothing.Repositories;

namespace Nothing.Services
{
    public class ProductService: CustomBaseService
    {
        private readonly ProductRepository _productRepo;
        private readonly FileRepository _fileRepo;
        public ProductService(ApplicationDbContext context) : base(context)
        {
            _productRepo = new ProductRepository(context);
            _fileRepo = new FileRepository(context);
        }


        public async Task<Product> Create(ProductCreate product)
        {
            var model = new Product()
            {
                CategoryId = null,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                EquityPrice = product.EquityPrice,
                Quantity = product.Quantity,
                UniquePiece = product.UniquePiece,
                Date = DateTime.Now,
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Product> Edit(ProductEdit product)
        {
            var model = await _productRepo.GetProductById(product.Id);

            model.Name = product.Name;
            model.Description = product.Description;    
            model.Price = product.Price;
            model.EquityPrice = product.EquityPrice;
            model.Quantity = product.Quantity;
            model.UniquePiece = product.UniquePiece;
            model.Date = DateTime.Now;

            _context.Update(model);
            await _context.SaveChangesAsync();

            var files = await _fileRepo.GetListFileByProductId(product.Id);
            _context.RemoveRange(files);
            await _context.SaveChangesAsync();

            return model;
        }


        public async Task<List<ProductGet>> GetListProduct()
        {
            var listProduct = await _productRepo.GetListProduct();
            var listFiles = await _fileRepo.GetListFileByProductIds(listProduct.Select(a => a.Id).ToList());

            var response = new List<ProductGet>();

            foreach (var item in listProduct) {
                var model = new ProductGet();
                var files = listFiles.Where(a => a.ProductId == item.Id).ToList();

                model.Product = item;
                model.Files = files;

                response.Add(model);
            }

            return response;
        }

        public async Task<ProductGet> GetProductById(Guid productId)
        {
            var product = await _productRepo.GetProductById(productId);
            var listFiles = await _fileRepo.GetListFileByProductId(productId);

            var response = new ProductGet();
            response.Product = product;
            response.Files = listFiles;

            return response;
        }

        
        public async Task<List<ProductGet>> GetListBestProduct()
        {
            var listProduct = await _productRepo.GetListBestProduct(5);
            var listFiles = await _fileRepo.GetListFileByProductIds(listProduct.Select(a => a.Id).ToList());

            var response = new List<ProductGet>();

            foreach (var item in listProduct)
            {
                var model = new ProductGet();
                var files = listFiles.Where(a => a.ProductId == item.Id).ToList();

                model.Product = item;
                model.Files = files;

                response.Add(model);
            }

            return response;
        }











        public async Task<List<ProductGet>> GetProductByListId([FromForm] List<Guid> listProductId)
        {
            var listProduct = await _productRepo.GetListProductByIds(listProductId);
            var listFiles = await _fileRepo.GetListFileByProductIds(listProductId);

            var response = new List<ProductGet>();

            foreach (var item in listProduct)
            {
                var model = new ProductGet();
                var files = listFiles.Where(a => a.ProductId == item.Id).ToList();

                model.Product = item;
                model.Files = files;

                response.Add(model);
            }

            return response;
        }
    }
}
