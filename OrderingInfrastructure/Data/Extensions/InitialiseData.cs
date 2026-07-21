namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialiseData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("00000000-0000-0000-0000-000000000001")), "mehmet", "Mehmet@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("00000000-0000-0000-0000-000000000002")), "john", "john@gmail.com")
        };

        public static IEnumerable<Product> Products =>
            new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("00000000-0000-0000-0000-000000000001")), "IPhone X", 500),
            Product.Create(ProductId.Of(new Guid("00000000-0000-0000-0000-000000000002")), "Samsung 10", 400)
        };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler", "Istanbul", "Turkey", "34100");
                var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "New York", "USA", "10001");

                var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
                var payment2 = Payment.Of("john", "8888555555554444", "06/30", "222", 2);

                // FIX: CustomerId now matches Mehmet (...0001)
                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("00000000-0000-0000-0000-000000000001")),
                    OrderName.Of("ORD_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1
                );

                // FIX: ProductIds now match IPhone (...0001) and Samsung (...0002)
                order1.Add(ProductId.Of(new Guid("00000000-0000-0000-0000-000000000001")), 2, 500);
                order1.Add(ProductId.Of(new Guid("00000000-0000-0000-0000-000000000002")), 1, 400);

                // FIX: CustomerId now matches John (...0002)
                var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("00000000-0000-0000-0000-000000000002")),
                    OrderName.Of("ORD_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment2
                );

                order2.Add(ProductId.Of(new Guid("00000000-0000-0000-0000-000000000001")), 1, 500);
                order2.Add(ProductId.Of(new Guid("00000000-0000-0000-0000-000000000002")), 2, 400);

                return new List<Order> { order1, order2 };
            }
        }
    }
}