using System.Collections.Generic;
using System.Linq;

namespace ex7.Models
{
    public class LinqValueCalculator: IValueCalculator
    {
        public decimal ValueProducts(IEnumerable<Product> products) {
            return products.Sum(p => p.Price);
        }
    }
}