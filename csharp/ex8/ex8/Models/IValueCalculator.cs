using System.Collections.Generic;

namespace ex8.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}
