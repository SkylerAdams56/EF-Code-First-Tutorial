using EF_Code_First_Tutorial;
using Microsoft.EntityFrameworkCore;

var _context = new SalesDbContext();

//_context.Customers.ToList().ForEach(c => Console.WriteLine(c.Name));

var order = _context.Orders.Include(x => x.OrderLines)
                           .ThenInclude(x => x.Item)
                           .Include(x => x.Customer)
                           .Single(x => x.Id == 2);

Console.WriteLine($"ORDER: {order.Description}");

foreach(var ol in order.OrderLines)
{
    Console.WriteLine($"ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
                      $"Price: {ol.Item.Price:C}, Line Total: {ol.Quantity * ol.Item.Price:C}");
}

var orderTotal = order.OrderLines.Sum(ol => ol.Item.Price * ol.Quantity);

Console.WriteLine($"Total: {orderTotal:C}");

