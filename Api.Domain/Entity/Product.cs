using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entity
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public bool ExistStock()
            => StockQuantity > 0;

        public bool IsZeroPrice()
            => Price <= 0;
    }
}
