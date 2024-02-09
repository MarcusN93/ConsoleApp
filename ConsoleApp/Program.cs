using ConsoleApp;
using ConsoleApp.Contexts;
using ConsoleApp.Repositories;
using ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CSharp-Projects\ConsoleApp\ConsoleApp\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));


    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<CustomerRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<RoleService>();
    services.AddScoped<ProductService>();
    services.AddScoped<CustomerService>();

    services.AddSingleton<ConsoleUI>();

}).Build();

bool menu = true;
var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();


while (menu)
{
    Console.Clear();
    Console.WriteLine("MENU OPTIONS");
    Console.WriteLine($"{"1.",-3} Create new product");
    Console.WriteLine($"{"2.",-3} Show all products");
    Console.WriteLine($"{"3.",-3} Update a product");
    Console.WriteLine($"{"4.",-3} Delete product");
    Console.WriteLine($"{"5.",-3} Create new customer");
    Console.WriteLine($"{"6.",-3} Show all customers");
    Console.WriteLine($"{"7.",-3} Update a customer");
    Console.WriteLine($"{"8.",-3} Delete Customer");
    Console.WriteLine($"{"0.",-3} Exit Application");
    Console.WriteLine();
    Console.Write("Enter Menu Option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            consoleUI.CreateProduct_UI();
            break;
        case "2":
            consoleUI.GetProducts_UI();
            break;
        case "3":
            consoleUI.UpdateProduct_UI();
            break;
        case "4":
            consoleUI.DeleteProduct_UI();
            break;
        case "5":
            consoleUI.CreateCustomer_UI();
            break;
        case "6":
            consoleUI.GetCustomer_UI();
            break;
        case "7":
            consoleUI.UpdateCustomer_UI();
            break;
        case "8":
            consoleUI.DeleteCustomer_UI();
            break;
        case "0":
            menu = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("\nInvalid Option Selected. Please try again");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            break;
    }
}