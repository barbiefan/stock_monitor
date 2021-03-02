using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace testtask1.Models
{
    public class StockPriceModel { }

    public class StockPrice
    {
        public DateTime date { get; set; }
        public decimal  price { get; set; }
        public float    change { get; set; }

    }
}

