// ICustomerRepository.cs
public interface ICustomerRepository
{
    void SaveCustomer(Customer customer);
}

// CustomerRepository.cs
public class CustomerRepository : ICustomerRepository
{
    public void SaveCustomer(Customer customer)
    {
        // Code to save customer to database
    }
}

// CustomerService.cs
public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void AddCustomer(Customer customer)
    {
        // Additional logic for adding a customer
        _customerRepository.SaveCustomer(customer);
    }
}

// Program.cs
...
services.AddTransient<ICustomerRepository, CustomerRepository>();
...