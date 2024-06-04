public class Product
{
    private string productName;
    private string productId;
    private decimal unitPrice;
    private int quantity;

    public Product(string productName, string productId, decimal unitPrice, int quantity)
    {
        this.productName = productName;
        this.productId = productId;
        this.unitPrice = unitPrice;
        this.quantity = quantity;
    }

    public decimal TotalCost()
    {
        return unitPrice * quantity;
    }

    public string ProductName => productName;
    public string ProductId => productId;
    public decimal UnitPrice => unitPrice;
    public int Quantity => quantity;
}
