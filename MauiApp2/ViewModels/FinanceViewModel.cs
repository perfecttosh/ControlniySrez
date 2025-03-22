using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MauiApp2.Models;
namespace MauiApp2.ViewModels
{


    public class FinanceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        FinanceListViewModel lvm;
        public FinanceModel Finance { get; private set; }

        public FinanceViewModel()
        {
            Finance = new FinanceModel();
        }

        public FinanceListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Title
        {
            get { return Finance.Title; }
            set
            {
                if (Finance.Title != value)
                {
                    Finance.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string Description
        {
            get { return Finance.Description; }
            set
            {
                if (Finance.Description != value)
                {
                    Finance.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public int Value
        {
            get { return Finance.Value; }
            set
            {
                if (Finance.Value != value)
                {
                    Finance.Value = value;
                    OnPropertyChanged("Value");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Title.Trim())) ||
                        (!string.IsNullOrEmpty(Description.Trim())) ||
                         (Value != 0));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

}
