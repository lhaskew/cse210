using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> productList;
    private Customer orderCustomer;

    public Order(Customer orderCustomer)
    {
        this.orderCustomer = orderCustomer;
        productList = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        productList.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal total = 0;
        foreach (var product in productList)
        {
            total += product.TotalCost();
        }
        total += orderCustomer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GeneratePackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        foreach (var product in productList)
        {
            packingLabel.AppendLine($"{product.ProductName} (ID: {product.ProductId})");
        }
        return packingLabel.ToString();
    }

    public string GenerateShippingLabel()
    {
        return $"{orderCustomer.FullName}\n{orderCustomer.CustomerAddress}";
    }
}
