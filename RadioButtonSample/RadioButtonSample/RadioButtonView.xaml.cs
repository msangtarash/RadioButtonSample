using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace RadioButtonSample
{
    [ContentProperty(nameof(Content))]
    public partial class RadioButtonView : TemplatedView
    {
        internal static List<WeakReference<RadioButtonView>> RadioButtonViews = new List<WeakReference<RadioButtonView>>();

        internal static void UnSelectOtherRadioButtonViews(RadioButtonView currentRadioButtonView)
        {
            foreach (WeakReference<RadioButtonView> radioButtonWeakReference in RadioButtonViews)
            {
                if (radioButtonWeakReference.TryGetTarget(out RadioButtonView radioButtonView) && radioButtonView != currentRadioButtonView && radioButtonView.Key.GetType() == currentRadioButtonView.Key.GetType())
                {
                    radioButtonView.IsSelected = false;
                }
            }
        }
        public RadioButtonView()
        {
            RadioButtonViews.Add(new WeakReference<RadioButtonView>(this));

            InitializeComponent();

            SelectedTappedCommand = new Command<RadioButtonView>(radioButton =>
            {
                Value = Key;
                IsSelected = true;
                UnSelectOtherRadioButtonViews(radioButton);
            });
        }

        public virtual void SelectedItemChanged()
        {
            if (Value.Equals(Key))
            {
                IsSelected = true;
            }               
        }

        public virtual View Content { get; set; }

        public bool IsSelected { get; protected set; }

        public ICommand SelectedTappedCommand { get; protected set; }

        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RadioButtonView), defaultValue: Color.Gray, defaultBindingMode: BindingMode.OneWay);

        public virtual Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static BindableProperty InerCircleColorProperty = BindableProperty.Create(nameof(InerCircleColor), typeof(Color), typeof(RadioButtonView), defaultValue: Color.Blue, defaultBindingMode: BindingMode.OneWay);

        public virtual Color InerCircleColor
        {
            get => (Color)GetValue(InerCircleColorProperty);
            set => SetValue(InerCircleColorProperty, value);
        }

        public static BindableProperty InerCircleRadiusProperty = BindableProperty.Create(nameof(InerCircleRadius), typeof(double), typeof(RadioButtonView), defaultValue: 12d, defaultBindingMode: BindingMode.OneWay);

        public virtual double InerCircleRadius
        {
            get => (double)GetValue(InerCircleRadiusProperty);
            set => SetValue(InerCircleRadiusProperty, value);
        }

        public static BindableProperty OuterCircleRadiusProperty = BindableProperty.Create(nameof(OuterCircleRadius), typeof(double), typeof(RadioButtonView), defaultValue: 20d, defaultBindingMode: BindingMode.OneWay);

        public virtual double OuterCircleRadius
        {
            get => (double)GetValue(OuterCircleRadiusProperty);
            set => SetValue(OuterCircleRadiusProperty, value);
        }

        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(RadioButtonView), defaultValue: null, defaultBindingMode: BindingMode.OneWay);

        public virtual string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(RadioButtonView), defaultValue: Color.Black, defaultBindingMode: BindingMode.OneWay);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static BindableProperty KeyProperty = BindableProperty.Create(nameof(Key), typeof(object), typeof(RadioButtonView), defaultValue: null, defaultBindingMode: BindingMode.OneWay);

        public virtual object Key
        {
            get => GetValue(KeyProperty);
            set => SetValue(KeyProperty, value);
        }

        public static BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(object), typeof(RadioButtonView), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: (sender, oldValue, newValue) =>
        {
            RadioButtonView radioButtonView = (RadioButtonView)sender;
            radioButtonView.SelectedItemChanged();
        });

        public virtual object Value
        {
            get =>  (object)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}