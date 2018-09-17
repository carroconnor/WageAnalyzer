using System;
using System.Text.RegularExpressions;
using WageAnalyzer.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WageAnalyzer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WageCollector : ContentPage
    {
        WageCollectorViewModel model;

        public WageCollector()
        {
            InitializeComponent();
            model = new WageCollectorViewModel();
            BindingContext = model;
            DayHours.TextChanged += HoursEntry_TextChanged;
            DayMinutes.TextChanged += MinutesEntry_TextChanged;
        }

        string previousHourInput;
        string previousMinuteInput;
        string previousMoneyInput;

        protected void HoursEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg = new Regex(@"^$|^(2[0-4]|1[0-9]|[1-9])$");
            Match matchHour = reg.Match(DayHours.Text);
            if (matchHour.Success)
            {
                previousHourInput = DayHours.Text;
            }
            else
            {
                DayHours.Text = e.OldTextValue;
            }
        }

        protected void MinutesEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg = new Regex(@"^$|^[1-5]?[0-9]$");
            Match matchMinute = reg.Match(DayMinutes.Text);
            if (matchMinute.Success)
            {
                previousMinuteInput = DayMinutes.Text;
            }
            else
            {
                DayMinutes.Text = e.OldTextValue;
            }
        }

        protected void MoneyEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg = new Regex(@"^$|^[1-5]?[0-9]$");
            Match matchMoney = reg.Match(DayWages.Text);
            if (matchMoney.Success)
            {
                previousMoneyInput = DayWages.Text;
            }
            else
            {
                DayWages.Text = e.OldTextValue;
            }
        }

        public void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            float float1 = 1;
            float float2 = 2;

            App.WageRepo.AddNewWage(float.TryParse(DayWages.Text, out), float.TryParse(DayHours.Text, out), float.TryParse(DayMinutes.Text, out), Restaurant.Text);
            statusMessage.Text = App.WageRepo.StatusMessage;
        }
    }
}