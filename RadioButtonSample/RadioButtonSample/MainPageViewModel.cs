using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RadioButtonSample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainPageViewModel()
        {

        }
    }

    public enum Gender
    {
        Men, Femail, Other
    }

    public class Person : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
