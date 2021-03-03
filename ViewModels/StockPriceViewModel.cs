using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using testtask1.Models;

namespace testtask1
{
    public class StockPriceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static int REFRESHTIME = 86400000;

        private List<StockPrice> data;
        private int amount;
        private string text;
        private bool refreshbool;
        
        private List<int> amountoptions = new List<int> { 10, 30, 50, 100, 150, 365, 730 };
        public bool RefreshBool
        {
            get
            {
                return (this.refreshbool);
            }
            set
            {
                if (value != this.refreshbool) 
                {
                    this.refreshbool = value;
                    NotifyPropertyChanged("RefreshBool");
                    this.LoadPrices();
                }
            }
        }

        public string TextBoxText
        {
            get
            {
                return (this.text);
            }
            set
            {
                if (value != this.text)
                {
                    this.text = value;
                    NotifyPropertyChanged("TextBoxText");
                }
            }
        }

        public List<int> AmountOptions
        {
            get
            {
                return (this.amountoptions);
            }
            set
            {
                if (value != this.amountoptions)
                {
                    this.amountoptions = value;
                    NotifyPropertyChanged("AmountOptions");
                }
            }
        }

        public int Amount
        {
            get
            {
                return (this.amount);
            }
            set
            {
                if (value != this.amount)
                {
                    this.amount = value;
                    NotifyPropertyChanged("Amount");
                }
            }
        }
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
        }

        public void LoadPrices()
        {
            if (this.amount > 0)
            {
                List<DateTime> dates = new List<DateTime>
                {
                    DateTime.Now.AddDays(-this.amount),
                    DateTime.Now
                };

                this.Data = ServerIO.GetPrices(dates);
                var last = this.Data[this.Data.Count - 1];
                this.TextBoxText = String.Format("Курс на {0} - {1}", last.Date.ToShortDateString(), last.Price);
            }
            if (this.RefreshBool)
            {
                this.ScheduleLoad();
            }
        }


        public async void ScheduleLoad()
        {
            await Task.Delay(REFRESHTIME);
            this.LoadPrices();
        }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
