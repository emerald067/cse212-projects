/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: can i add one customer and then serve the customer?  
        // Expected Result: This should display the customer that was added
        Console.WriteLine("Test 1");

        var service = new CustomerService(4);
        service.AddNewCustomer();
        service.ServeCustomer();

        // Defect(s) Found: ServeCustomer() removed the first customer before retrieving it, causing an error when there was only one customer.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve both customers
        // Expected Result: The first customer added should be served first, followed by the second customer added
        Console.WriteLine("Test 2");

        var service2 = new CustomerService(4);
        service2.AddNewCustomer();
        service2.AddNewCustomer();
        service2.ServeCustomer();
        service2.ServeCustomer();

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Try to serve a customer when the queue is empty
        // Expected Result: Display an error message instead of crashing
        Console.WriteLine("Test 3");

        var service3 = new CustomerService(4);
        service3.ServeCustomer();

        // Defect(s) Found: ServeCustomer() did not check if the queue was empty before accessing the first customer.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Try to add 5 customers to a queue with a maximum size of 4
        // Expected Result: The fifth customer should not be added and an error message should be displayed
        Console.WriteLine("Test 4");

        var service4 = new CustomerService(4);
        service4.AddNewCustomer();
        service4.AddNewCustomer();
        service4.AddNewCustomer();
        service4.AddNewCustomer();
        service4.AddNewCustomer();

        // Defect(s) Found: AddNewCustomer() used > instead of >=, allowing a customer to be added when the queue was already full.

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Create a customer service queue with a maximum size of 0
        // Expected Result: The maximum queue size should default to 10
        Console.WriteLine("Test 5");

        var service5 = new CustomerService(0);
        Console.WriteLine(service5);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}