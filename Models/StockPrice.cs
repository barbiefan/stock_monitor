using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace testtask1.Models
{
    public class StockPriceModel { }

    public class StockPrice : INotifyPropertyChanged
    {
        private DateTime date;
        private float    price;
        private float    change;

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        public float Price
        {
            get { return price; }

            set
            {
                if (price != value)
                {
                    price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }

        public float Change
        {
            get
            {
                return change;
            }

            set
            {
                if (change != value)
                {
                    change = value;
                    RaisePropertyChanged("Change");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

