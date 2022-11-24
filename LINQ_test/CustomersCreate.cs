using LINQ_test.database;
using System;
using System.Linq;

namespace LINQ_test;
public static class CustomersCreator
{
    public static IEnumerable<Customer> CreateCustomers()
    {
        yield return new Customer("Kaneki Ken", 31, new[]
        {
            new Order(new DateOnly(2020, 10, 16), 100000),
            new Order(new DateOnly(2006, 06, 06), 110000)
        });

        yield return new Customer("Alexey Navalny", 46, new[]
        {
            new Order(new DateOnly(2019, 05, 01), 220000),
            new Order(new DateOnly(2002, 02, 02), 20000)
        });

        yield return new Customer("Vladimir Putin", 70, new[]
        {
            new Order(new DateOnly(2020, 10, 16), 300)
        });

        yield return new Customer("Ivan Ivanov", 57, new[]
        {
            new Order(new DateOnly(1922, 10, 1), 10300),
            new Order(new DateOnly(2010, 7, 1), 20300),
            new Order(new DateOnly(2020, 10, 16), 337500)
        });

    }
}
