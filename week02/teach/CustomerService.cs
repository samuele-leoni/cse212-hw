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
        // Scenario: Two Customer Service Queue will be created with different maxSize parameter passed. 
        // The first will have maxSize = 0 and the second maxSize = -1.
        // Expected Result: The first should have maxSize = 10.
        Console.WriteLine("Test 1");

        var customerServiceQueue = new CustomerService(0);
        Console.WriteLine(customerServiceQueue._maxSize == 10 ? "The queue with maxSize = 0 works!" : "ERROR: The queue with maxSize = 0 doesn't work!");

        customerServiceQueue = new CustomerService(-1);
        Console.WriteLine(customerServiceQueue._maxSize == 10 ? "The queue with maxSize = -1 works!" : "ERROR: The queue with maxSize = -1 doesn't work!");

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 2
        // Scenario: A maxSize variable of 3 will be created and then a for loop will cycle one time more than the
        // maxSize value adding a new customer using the method AddNewCustomer.
        // Expected Result: The queue should have 3 customers and then throw an error for the sixth.
        Console.WriteLine("Test 2");

        var maxSize = 3;
        customerServiceQueue = new CustomerService(maxSize);

        for (int i = 0; i <= maxSize; i++)
        {
            customerServiceQueue.AddNewCustomer();
        }

        Console.WriteLine(customerServiceQueue._queue.Count == maxSize ? "The queue has 3 customers!" : $"ERROR: The queue has {customerServiceQueue._queue.Count} customers instead of 3!");

        // Defect(s) Found: The condition was checking if _queue.Count was greather than maxSize but it should've checked
        // when it becomes equal.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Using the previously added customers the ServeCustomer method will be called one time more than
        // the queue actual content.
        // Expected Result: The queue should have 0 customers and throw an error for the last call of ServeCustomer.
        Console.WriteLine("Test 3");

        for (int i = 0; i <= maxSize; i++)
        {
            customerServiceQueue.ServeCustomer();
        }

        Console.WriteLine(customerServiceQueue._queue.Count == 0 ? "The queue is empty, it works!" : $"ERROR: The queue has {customerServiceQueue._queue.Count} customers instead of 0!");

        // Defect(s) Found: The whole content of the ServeCustomer method should be wrapped in a try catch to handle
        // the ArgumentOutOfRangeException and the customer was stored in a variable after removing it which would cause
        // the console to print out the wrong customer.

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
        try
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
        catch(ArgumentOutOfRangeException)
        {
            Console.WriteLine("Queue already empty!");
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}