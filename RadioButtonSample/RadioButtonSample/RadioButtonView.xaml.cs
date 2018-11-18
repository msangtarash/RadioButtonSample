using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            foreach (var radioButtonWeakReference in RadioButtonViews)
            {
                if (radioButtonWeakReference.TryGetTarget(out RadioButtonView radioButtonView) && radioButtonView != currentRadioButtonView && radioButtonView.Type == currentRadioButtonView.Type)
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
                IsSelected = !IsSelected;
                UnSelectOtherRadioButtonViews(radioButton);
            });
        }

        public virtual Xamarin.Forms.View Content { get; set; }

        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RadioButtonView), defaultValue: Color.Gray, defaultBindingMode: BindingMode.OneWay);

        public virtual Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static BindableProperty InerCircleColorProperty = BindableProperty.Create(nameof(InerCircleColor), typeof(Color), typeof(RadioButtonView), defaultValue: Color.White, defaultBindingMode: BindingMode.OneWay);

        public virtual Color InerCircleColor
        {
            get => (Color)GetValue(InerCircleColorProperty);
            set => SetValue(InerCircleColorProperty, value);
        }

        public static BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(RadioButtonView), defaultValue: false, defaultBindingMode: BindingMode.TwoWay);

        public virtual bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
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

        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(RadioButtonView), defaultValue: Color.Black, defaultBindingMode: BindingMode.OneTime);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public ICommand SelectedTappedCommand { get; set; }

        public static BindableProperty KeyProperty = BindableProperty.Create(nameof(Key), typeof(string), typeof(RadioButtonView), defaultValue: null, defaultBindingMode: BindingMode.OneWay);

        public virtual string Key
        {
            get => (string)GetValue(KeyProperty);
            set => SetValue(KeyProperty, value);
        }

        public static BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(Type), typeof(RadioButtonView), defaultValue: null, defaultBindingMode: BindingMode.OneWay);

        public virtual Type Type
        {
            get => (Type)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(object), typeof(RadioButtonView), defaultValue: null, defaultBindingMode: BindingMode.TwoWay);

        public virtual object Value
        {
            get => (object)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}