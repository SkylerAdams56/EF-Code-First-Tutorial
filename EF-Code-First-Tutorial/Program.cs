
using EF_Code_First_Tutorial.Controllers;

var custCtrl = new CustomersController();

var customer = await custCtrl.GetCustomerWithOrders(1);

Console.WriteLine($"CUSTOMER: {customer.Name}");
foreach (var ord in customer.Orders)
{
    Console.WriteLine($"- ORDER: Description {ord.Description}");
    foreach (var ol in ord.OrderLines)
    {
        Console.WriteLine($"-- ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
                  $"Price: {ol.Item.Price:C}, Line Total: {ol.Quantity * ol.Item.Price:C}");
    }
}







//using EF_Code_First_Tutorial;
//using Microsoft.EntityFrameworkCore;

//var _context = new SalesDbContext();



//var customer = _context.Customers.Include(x => x.Orders)
//                                 .ThenInclude(x => x.OrderLines)
//                                 .ThenInclude(x => x.Item)
//                                 .Single(x => x.Id == 1);


//Console.WriteLine($"CUSTOMER: {customer.Name}");
//foreach(var ord in customer.Orders)
//{
//    Console.WriteLine($"- ORDER: Description {ord.Description}");
//    foreach(var ol in ord.OrderLines)
//    {
//        Console.WriteLine($"-- ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
//                  $"Price: {ol.Item.Price:C}, Line Total: {ol.Quantity * ol.Item.Price:C}");
//    }
//}

//_context.Customers.ToList().ForEach(c => Console.WriteLine(c.Name));

//var order = _context.Orders.Include(x => x.OrderLines)
//                              .ThenInclude(x => x.Item)
//                           .Include(x => x.Customer)
//                           .Single(x => x.Id == 2);

//Console.WriteLine($"ORDER: {order.Description}");

//foreach(var ol in order.OrderLines)
//{
//    Console.WriteLine($"ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
//                      $"Price: {ol.Item.Price:C}, Line Total: {ol.Quantity * ol.Item.Price:C}");
//}

//var orderTotal = order.OrderLines.Sum(ol => ol.Item.Price * ol.Quantity);

//Console.WriteLine($"Total: {orderTotal:C}");

