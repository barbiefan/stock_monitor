using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Data;
using testtask1.cbrf;


namespace testtask1.Models
{
    class ServerIO
    {
        private static string CODE = "R01235";
        public static List<StockPrice> GetPrices(List<DateTime> dates)
        {
            List<StockPrice> priceslist = new List<StockPrice>();

            var daily = new DailyInfo();
            var dynamic = daily.GetCursDynamic(dates[0], dates[1], CODE);

            bool first = true;
            foreach (DataRow row in dynamic.Tables[0].Rows)
            {
                StockPrice price = new StockPrice();
                price.Date = (DateTime)row.ItemArray[0];
                price.Price = (decimal)row.ItemArray[3];
                if (!first)
                {
                    float old = (float)priceslist[priceslist.Count - 1].Price;
                    price.Change = 100 * ((float)price.Price - old) / old;
                }
                else
                {
                    first = false;
                }
                priceslist.Add(price);
                price = null;
            }
            foreach(StockPrice item in priceslist)
            {
                Console.WriteLine(item.Date.ToShortDateString());
            }
            return (priceslist);
        }
    }
}
