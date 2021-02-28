using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtask1.Models;

namespace testtask1.ViewModels
{
    public class StockPriceViewModel
    {
        public ObservableCollection<StockPrice> Prices { get; set; }
        
        /// <summary>
        /// Get stock prices from CBR API
        /// </summary>
        /// <param name="dates">list of DateTime objects to load prices for</param>
        private void GetPrices(List<DateTime> dates)
        {

        }

        /// <summary>
        /// Load stock prices into Prices property
        /// </summary>
        /// <param name="amount">amount of prices to Get</param>
        /// <param name="interval">interval between each price date</param>
        public void LoadPrices(int amount, DateTime interval)
        {

        }
    }
}
