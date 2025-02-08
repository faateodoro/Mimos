namespace Mimos.API.Models.DTO;

public record ProductForm(string Name, string Description, string CodeBar, int Amount, decimal BuyingPrice, decimal SellingPrice)
{
}
