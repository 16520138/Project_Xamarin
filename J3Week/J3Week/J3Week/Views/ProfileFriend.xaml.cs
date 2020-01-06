using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using J3Week.Models;
using System.IO;

namespace J3Week.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileFriend : ContentPage
    {
    
        public Geocoder geoCoder;
        public ProfileFriend(Datum datum)
        {
            InitializeComponent();
            txtname.Text = datum.firstname + " " + datum.lastname;
            txtage.Text = datum.age.ToString();
            txtcity.Text = datum.city;
            txtjob.Text = datum.jobtitle;
            txtphone.Text = datum.phone;
            txtstreet.Text = datum.street;
            avatar.Source = datum.avatar;
            txtemail.Text = datum.email;
            map(datum);
        }


        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        private void Back(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        private void Edit(object sender, System.EventArgs e)
        {

        }
        public void map(Datum datum)
        {
            var mapPosition = new Position();
            if (datum.email == "tanvn@uit.edu.vn")
            {
               mapPosition = new Position(13.759660, 109.206123);
            }
            else if(datum.email == "huynhduchuydt@gmail.com")
            {
                mapPosition = new Position(11.936230, 108.445260);
            }
            else if (datum.email == "cuongdong7@gmail.com")
            {
                mapPosition = new Position(17.753410, 106.420310);
            }

            var mapPin = new Pin
            {
                Type = PinType.Place,
                Position = mapPosition,
                Label = "UIT",
                Address = "University"
            };


            MyMap.Pins.Clear();

            MyMap.Pins.Add(mapPin);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, Distance.FromMiles(1)));
        }

        private async void buttonSms(object sender, EventArgs e)
        {
            try
            {

                var smsTask = MessagingPlugin.SmsMessenger;
                if (smsTask.CanSendSms)
                    smsTask.SendSms(txtphone.Text, "Hello World");
                else
                {
                    await DisplayAlert("Error", "This device can't send sms", "OK");
                }
            }
            catch
            {
                // await DisplayAlert("Error", "Unable to perform action", "OK");
            }
        }

        private async void buttonCall(object sender, EventArgs e)
        {
            try
            {
                // make phone call
                var phonecalltask = MessagingPlugin.PhoneDialer;
                if (phonecalltask.CanMakePhoneCall)
                {
                    phonecalltask.MakePhoneCall(txtphone.Text);
                    Debug.WriteLine("call!");
                }
                else
                    await DisplayAlert("error", "this device can't place calls", "ok");
            }
            catch
            {
                // await displayalert("error", "unable to perform action", "ok");
            }
        }

        private async void btnEmail(object sender, EventArgs e)
        {
            try
            {
                var emailTask = MessagingPlugin.EmailMessenger;
                if (emailTask.CanSendEmail)
                    emailTask.SendEmail(txtemail.Text, "Hello there!", "This was sent from the Xamrain Messaging Plugin from shared code!");
                else
                    await DisplayAlert("Error", "This device can't send emails", "OK");
            }
            catch
            {
                //await DisplayAlert("Error", "Unable to perform action", "OK");
            }
        }
    }
}