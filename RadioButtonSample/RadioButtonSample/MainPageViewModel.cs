using System.Collections.Generic;
using System.ComponentModel;

namespace RadioButtonSample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Person Person { get; set; }

        public MainPageViewModel()
        {
            Person = new Person
            {
                Name = "Yas",
                Gender = Gender.Man
            };
        }
    }

    public enum Gender
    {
        Man, Woman, Other
    }

    public class Person : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
