using LINQ_test;

var customers = CustomersCreator.CreateCustomers();

#region общее кол-во клиентов
Console.WriteLine($"Количество клиентов: {customers.Count()}");
#endregion

#region имя клиентов и кол-во заказов
foreach (var customer in customers)
    Console.WriteLine("Имя клиента: {0}; Количество заказов: {1}", customer.Name, customer.Orders.Count());

#endregion

#region средний возраст клиентов,где хотя бы 1 заказ больше 10000
Console.WriteLine($"Средний возраст клиентов,где хотя бы 1 заказ больше 10000: {customers.Where(x => x.Orders.Select(a => a.Amount).Any(t => t > 10000) == true).Select(s => s.Age).Average()}");
#endregion

#region даты всех заказов без повторов
var sortDate = customers.SelectMany(e => e.Orders.Select(p => p.Date)).Distinct();
foreach (var date in sortDate)
    Console.WriteLine($"Дата заказа: {date}");
#endregion

#region имя клиента, где общая сумма больше 200000, есть один заказ в 2020г,  сумма каждого заказа больше 10000 
foreach (var c in customers)
    if ((c.Orders.Any(i => i.Date.Year == 2020) == true) && (c.Orders.Select(i => i.Amount).Sum() > 200000) && (c.Orders.All(i => i.Amount > 10000) == true))
        Console.WriteLine($"Имя клиента: {c.Name}");
#endregion

#region даты и количества заказов в каждую дату
// условия:
// 1. стоимость заказа > 10000
// 2. клиент имеет хотя бы один заказ стоимостью > 100000
// 3. в дату не менее 1 заказа, либо год 2002
// 4. сортировка дат в порядке возрастания
var data = customers.Where(u => u.Orders.All(r => r.Amount > 10000) && u.Orders.Any(r => r.Amount > 100000))
    .SelectMany(u => u.Orders.Select(u => u.Date));
var sort_Data = data.Where(u => u.Year == 2002 || data.Count(r => r == u) > 1);
sort_Data.GroupBy(x => x).OrderBy(g => g.Count()).Select(g => g.Key).ToList()
    .ForEach(x => Console.WriteLine($"Дата: {x}; Количество заказов: {sort_Data.Count(r => r == x)}"));
#endregion

Console.ReadKey();