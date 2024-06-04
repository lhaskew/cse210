public class Customer
{
    private string fullName;
    private Address customerAddress;

    public Customer(string fullName, Address customerAddress)
    {
        this.fullName = fullName;
        this.customerAddress = customerAddress;
    }

    public bool IsInUSA()
    {
        return customerAddress.IsInUSA();
    }

    public string FullName => fullName;

    public Address CustomerAddress => customerAddress;
}
