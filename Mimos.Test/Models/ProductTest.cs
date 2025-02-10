using Mimos.API.Models;
using Mimos.API.Models.DTO;

namespace Mimos.Test.Models;

public class ProductTest
{
    [Fact]
    public void Update__Should_return_valid_product()
    {
        var product = new Product("Sabonete", "Sabonete cheiroso", "789123456", 15, 19.80m, 27.50m);

        var form = new ProductForm("Sabonete de Macadamia", "Tem cheiro de macadamia", "789456123", 12, 19.8m, 29.9m);

        product.Update(form);

        Assert.True(product.Name == "Sabonete de Macadamia");
        Assert.True(product.Description == "Tem cheiro de macadamia");
        Assert.True(product.CodeBar == "789456123");
        Assert.True(product.Amount == 12);
        Assert.True(product.BuyingPrice == 19.8m);
        Assert.True(product.SellingPrice == 29.9m);

    }
}