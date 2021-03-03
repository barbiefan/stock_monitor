using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtask1.Models;

namespace testtask1
{
    public class StockPriceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<StockPrice> data;
        public List<StockPrice> Data
        {
            get
            {
                return (this.data);
            }
            set
            {
                if (value != this.data)
                {
                    this.data = value;
                    NotifyPropertyChanged("Data");
                }
            }
        }

        /// <summary>
        /// Load stock prices into Prices property
        /// </summary>
        public StockPriceViewModel()
        {
            //this.LoadPrices();
        }

        public void LoadPrices()
        {
            int amount = 35;
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Now.AddDays(-amount));
            dates.Add(DateTime.Now);

            this.data = ServerIO.GetPrices(dates);
            NotifyPropertyChanged("Data");
        }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
