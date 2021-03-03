using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace testtask1.Models
{
    public class StockPrice : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime date;
        private decimal price;
        private float change;

        public DateTime Date
        {
            get
            {
                return (this.date);
            }

            set
            {
                if (value != this.date)
                {
                    this.date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }
        public decimal Price
        {
            get
            {
                return (this.price);
            }

            set
            {
                if (value != this.price)
                {
                    this.price = value;
                    NotifyPropertyChanged("Price");
                }
            }
        }
        public float Change
        {
            get
            {
                return (this.change);
            }

            set
            {
                if (value != this.change)
                {
                    this.change = value;
                    NotifyPropertyChanged("Change");
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

