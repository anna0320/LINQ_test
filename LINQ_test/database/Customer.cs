namespace LINQ_test.database;
public record Customer(string Name, int Age, IEnumerable<Order> Orders);
