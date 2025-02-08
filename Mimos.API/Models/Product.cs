using Mimos.API.Models.DTO;
using System.Xml.Linq;

namespace Mimos.API.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string CodeBar { get; private set; }
        public int Amount { get; private set; }
        public decimal BuyingPrice { get; private set; }
        public decimal SellingPrice { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public Product(string name, string description, string codeBar, int amount, decimal buyingPrice, decimal sellingPrice)
        {
            Name = name;
            Description = description;
            CodeBar = codeBar;
            Amount = amount;
            BuyingPrice = buyingPrice;
            SellingPrice = sellingPrice;
        }

        public Product(ProductForm dto)
        {
            Name = dto.Name;
            Description = dto.Description;
            CodeBar = dto.CodeBar;
            Amount = dto.Amount;
            BuyingPrice = dto.BuyingPrice;
            SellingPrice = dto.SellingPrice;
        }
        
    }
}
