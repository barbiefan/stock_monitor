using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtask1.Models;

namespace testtask1
{
    public class StockPriceViewModel
    {
        public List<StockPrice> Data { get; set; }

        /// <summary>
        /// Load stock prices into Prices property
        /// </summary>
        /// <param name="amount">amount of prices to Get</param>
        /// <param name="interval">interval between each price date in minutes</param>
        public StockPriceViewModel()
        {
            Data = new List<StockPrice>();

            int amount = 35;
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Now.AddDays(-amount));
            dates.Add(DateTime.Now);

            Data = ServerIO.GetPrices(dates);
        }
    }
}
