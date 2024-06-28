using System.Text;

namespace BurgerBytes.UI;

public class Program
{
    private static Dictionary<char, string> _options;
    private static Dictionary<int, MenuItem> _menu;
    private static List<Order> _orders;
    
    private static Dictionary<char, string> BuildOptions()
    {
        return new Dictionary<char, string>
        {
            { '1', "Create order" },
            { '2', "View all orders" },
            { '3', "Exit" }
        };
    }
    
    private static Dictionary<int, MenuItem> BuildMenu()
    {
        return new Dictionary<int, MenuItem>
        {
            { 1, new MenuItem { Name = "ByteBurger", Price = 5.99m } },
            { 2, new MenuItem { Name = "BitFries", Price = 1.99m } },
            { 3, new MenuItem { Name = "HashBrown", Price = 0.99m } },
            { 4, new MenuItem { Name = "ClassCola", Price = 1.50m } },
            { 5, new MenuItem { Name = "StackShake", Price = 3.50m } }
        };
    }
    
    private static void DisplayOptionsMenu()
    {
        foreach (var option in _options)
        {
            Console.WriteLine($"{option.Key}. {option.Value}");
        }

        Console.Write("\nSelect: ");
    }
    
    private static char GetOption()
    {
        var option = '\0';
        
        while (!_options.ContainsKey(option))
        {
            var input = Console.ReadKey(true).KeyChar.ToString();
            option = char.Parse(input);
        }

        Console.WriteLine(option);
        
        return option;
    }
    
    private static void DisplayMenu()
    {
        var menu = new StringBuilder();

        menu.AppendLine("\n|-----------------------|--------|");
        menu.AppendLine("| Item                  | Price  |");
        menu.AppendLine("|-----------------------|--------|");

        foreach (var option in _menu)
        {
            menu.AppendLine($"| {option.Key}. {option.Value.Name,-19}| {option.Value.Price,-6} |");
        }

        menu.Append("|-----------------------|--------|");
        
        Console.WriteLine(menu.ToString());
    }
    
    private static Order StartNewOrder()
    {
        Console.Write("Staff Id: ");
        var staffId = Console.ReadLine();
        
        Console.Write("Table No.: ");
        var tableNumber = Console.ReadLine();

        return new Order
        {
            StaffId = staffId,
            TableNumber = tableNumber,
            Items = [],
            Tip = 0
        };
    }
    
    // private static OrderItem GetOrderItem()
    // {
    //     Console.Write("Enter item: ");
    //     var name = Console.ReadLine();
    //         
    //     Console.Write("Enter price: ");
    //     var input = Console.ReadLine();
    //
    //     Console.Write("Enter quantity: ");
    //     var quantity = Console.ReadLine();
    //
    //     decimal price;
    //     while (!decimal.TryParse(input, out price))
    //     {
    //         Console.WriteLine("Invalid price!");
    //         Console.Write("Enter price: ");
    //         input = Console.ReadLine();
    //     }
    //     
    //     return new OrderItem
    //     {
    //         Name = name,
    //         Price = price,
    //         Quantity = int.Parse(quantity)
    //     };
    // }

    private static OrderItem GetOrderLine()
    {
        Console.Write("Enter item No.: ");
        var item = int.Parse(Console.ReadLine());

        if (!_menu.TryGetValue(item, out var menuItem)) {
            // TODO: what happens when selection is invalid?
        }
        
        Console.Write("Enter quantity: ");
        var quantity = int.Parse(Console.ReadLine());
        
        return new OrderItem
        {
            Name = menuItem.Name,
            Price = menuItem.Price,
            Quantity = quantity
        };
    }
    
    private static int GetOrderTip()
    {
        Console.Write("Enter tip(%): ");
        var input = Console.ReadLine();

        _ = int.TryParse(input, out var tip);
        
        if (tip < 0)
        {
            tip = 0;
        }
        
        return tip;
    }

    private static bool AddMoreItems()
    {
        var exit = false;
        var input = ConsoleKey.None;
        
        while (input != ConsoleKey.Y && input != ConsoleKey.N)
        {
            input = Console.ReadKey(true).Key;

            exit = input switch
            {
                ConsoleKey.N => false,
                ConsoleKey.Y => true,
                _ => exit
            };
        }

        return exit;
    }
    
    private static void PrintOrder(Order customerOrder)
    {
        Console.WriteLine();
        Console.WriteLine($"Staff Id: {customerOrder.StaffId}");
        Console.WriteLine($"Table No.: {customerOrder.TableNumber}\n");
        
        Console.WriteLine("Item         Quantity   Price  ");
        Console.WriteLine("-------------------------------");

        var orderTotal = 0m;
        
        foreach (var item in customerOrder.Items)
        {
            var lineTotal = item.Price * item.Quantity;
            orderTotal += lineTotal;
            
            Console.WriteLine($"{item.Name,-12} {item.Quantity, -10} {lineTotal:C}");
        }

        var orderTip = (orderTotal / 100) * customerOrder.Tip;
        Console.WriteLine($"\nTip: {orderTip:C}");
        Console.WriteLine($"Total: {orderTotal + orderTip:C}");
    }
    
    private static void CreateOrder()
    {
        var customerOrder = StartNewOrder();
        
        DisplayMenu();
        
        do
        {
            Console.WriteLine();
            customerOrder.Items.Add(GetOrderLine());
            
            Console.Write("Add another item (y/n): ");
        } while (AddMoreItems());

        Console.WriteLine();
        customerOrder.Tip = GetOrderTip();
        
        _orders.Add(customerOrder);
        
        PrintOrder(customerOrder);
        
        Console.WriteLine();
    }

    private static void ViewOrders()
    {
        if (_orders.Count == 0)
        {
            Console.WriteLine("No orders taken yet");
        }
        else
        {
            Console.WriteLine();
        }
        
        foreach (var order in _orders)
        {
            var orderTotal = 0m;
            
            Console.WriteLine("".PadRight(30, '-'));
            Console.WriteLine($"Order Id: {order.OrderId}");
            Console.WriteLine($"Staff Id: {order.StaffId}");
            Console.WriteLine($"Table No.: {order.TableNumber}");
            foreach (var item in order.Items)
            {
                var itemTotal = item.Price * item.Quantity;
                orderTotal += itemTotal;
                Console.WriteLine($"{item.Name} ({item.Quantity}) - {itemTotal:C}");
            }

            Console.WriteLine($"Total: {orderTotal + (orderTotal / 100) * order.Tip:C} ({(orderTotal / 100) * order.Tip:C})");
        }

        Console.WriteLine();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Burger Bytes");
        Console.WriteLine("=======================\n");

        _options = BuildOptions();
        _menu = BuildMenu();
        _orders = [];
        var exit = false;
        
        do
        {
            DisplayOptionsMenu();

            switch (GetOption())
            {
                case '1':
                    CreateOrder();
                    break;
                case '2':
                    ViewOrders();
                    break;
                case '3':
                    exit = true;
                    break;
            }

        } while (!exit);
    }
}
