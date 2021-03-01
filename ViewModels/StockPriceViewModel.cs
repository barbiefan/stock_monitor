using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using testtask1.Models;
using testtask1.cbrf;

namespace testtask1.ViewModels
{
    public class StockPriceViewModel
    {
        public ObservableCollection<StockPrice> Prices { get; set; }
        
        /// <summary>
        /// Get stock prices from CBR API
        /// </summary>
        /// <param name="dates">list of DateTime objects to load prices for</param>
        private List<StockPrice> GetPrices(List<DateTime> dates)
        {
            List<StockPrice> priceslist = new List<StockPrice>();

            var daily = new DailyInfo();
            foreach(DateTime date in dates)
            {
                var curs = daily.GetCursOnDateXML(date);
                foreach(XmlNode node in curs)
                {
                    if (node["Vname"].InnerText.Contains("Доллар США")) 
                    {
                        Console.WriteLine(node["Vcurs"].InnerText);
                        float value = float.Parse((node["Vcurs"].InnerText.Trim()), CultureInfo.InvariantCulture);
                        StockPrice price = new StockPrice();
                        price.price = value;
                        price.date = date;
                        priceslist.Add(price);
                        price = null;
                        
                    }
                }
            }

            return (priceslist);
        }

        /// <summary>
        /// Load stock prices into Prices property
        /// </summary>
        /// <param name="amount">amount of prices to Get</param>
        /// <param name="interval">interval between each price date in minutes</param>
        public void LoadPrices(int amount, int interval)
        {
            List<DateTime> dates = new List<DateTime>();

            while (amount > 0)
            {
                dates.Add(DateTime.Now.AddMinutes(-(amount * interval)));
                amount--;
            }
            GetPrices(dates);
        }
    }
}
