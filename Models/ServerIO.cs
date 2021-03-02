﻿using System;
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
            var valutes = daily.EnumValutes(false);

            bool first = true;
            foreach (DataRow row in dynamic.Tables[0].Rows)
            {
                StockPrice price = new StockPrice();
                price.date = (DateTime)row.ItemArray[0];
                price.price = (decimal)row.ItemArray[3];
                if (!first)
                {
                    price.change = ((float)price.price - (float)priceslist[priceslist.Count - 1].price) / (float)price.price;
                }
                else
                {
                    first = false;
                }
                priceslist.Add(price);
                price = null;
            }
            
            return (priceslist);
        }
    }
}