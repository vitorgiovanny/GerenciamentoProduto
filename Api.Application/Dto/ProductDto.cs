using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

    }
}
