using Example.Generate.Pdf.App.Models;

namespace Example.Generate.Pdf.App.Services.ExampleData;

public class ExampleDataService
{
    public Order GetExampleData()
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = "+82 1033233238",
        };

        var orderId = Guid.NewGuid();
        var order = new Order
        {
            Id = orderId,
            Customer = customer,
            Details = new List<OrderDetail>
            {
                new() { Id = Guid.NewGuid(), Name = "New Item #1", OrderId = orderId, Price = 3.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #2", OrderId = orderId, Price = 0.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #3", OrderId = orderId, Price = 1.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #4", OrderId = orderId, Price = 2.99, Quantity = 1,  },

                new() { Id = Guid.NewGuid(), Name = "New Item #1", OrderId = orderId, Price = 3.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #2", OrderId = orderId, Price = 0.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #3", OrderId = orderId, Price = 1.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #4", OrderId = orderId, Price = 2.99, Quantity = 1,  },

                new() { Id = Guid.NewGuid(), Name = "New Item #1", OrderId = orderId, Price = 3.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #2", OrderId = orderId, Price = 0.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #3", OrderId = orderId, Price = 1.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #4", OrderId = orderId, Price = 2.99, Quantity = 1,  },


                new() { Id = Guid.NewGuid(), Name = "New Item #1", OrderId = orderId, Price = 3.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #2", OrderId = orderId, Price = 0.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #3", OrderId = orderId, Price = 1.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #4", OrderId = orderId, Price = 2.99, Quantity = 1,  },


                new() { Id = Guid.NewGuid(), Name = "New Item #1", OrderId = orderId, Price = 3.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #2", OrderId = orderId, Price = 0.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #3", OrderId = orderId, Price = 1.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #4", OrderId = orderId, Price = 2.99, Quantity = 1,  },


                new() { Id = Guid.NewGuid(), Name = "New Item #1", OrderId = orderId, Price = 3.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #2", OrderId = orderId, Price = 0.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #3", OrderId = orderId, Price = 1.99, Quantity = 1,  },
                new() { Id = Guid.NewGuid(), Name = "New Item #4", OrderId = orderId, Price = 2.99, Quantity = 1,  },
            },
        };

        return order;
    }
}
