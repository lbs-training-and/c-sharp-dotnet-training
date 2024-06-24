// CustomerRepository.cs
public class CustomerRepository
{
    public void SaveCustomer(Customer customer)
    {
        // Code to save customer to database
    }
}

// CustomerService.cs
public class CustomerService
{
    private CustomerRepository _customerRepository;

    public CustomerService()
    {
        _customerRepository = new CustomerRepository();
    }

    public void AddCustomer(Customer customer)
    {
        // Additional logic for adding a customer
        _customerRepository.SaveCustomer(customer);
    }
}