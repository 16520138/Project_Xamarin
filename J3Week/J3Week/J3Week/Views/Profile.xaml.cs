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
	public partial class Profile : ContentPage
	{
        public Datum user { get => GetUserInfo(); }
        public string userName { get => GetUserName(); }

        public ImageSource avatar { get => GetAvatar(); }

        private ImageSource GetAvatar()
        {

            byte[] data = Convert.FromBase64String(UserLogin.avatar);
            return ImageSource.FromStream(() => new MemoryStream(data));
        }

        private string GetUserName()
        {
            string name = UserLogin.name;
            return name;
        }
            private Datum GetUserInfo()
        {
            
            Datum test = new Datum();
            test.email = UserLogin.email;
            test.firstname = UserLogin.firstname;
            test.lastname = UserLogin.lastname;
            test.company = UserLogin.company;
            test.jobtitle = UserLogin.jobtitle;
            test.phone = UserLogin.phone;
            test.street = UserLogin.street;
            test.city = UserLogin.city;
            test.age = UserLogin.age; 
            test.avatar = UserLogin.avatar;
            return test;
        }


        public Geocoder geoCoder;
        public Profile ()
		{
			InitializeComponent ();
            BindingContext = this;
            map();
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
            Debug.WriteLine("Edit infomation");
        }
        public void map()
        {
            var mapPosition = new Position(10.924067, 106.713028);

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
                    smsTask.SendSms(phone.Text, "Hello World");
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
                    phonecalltask.MakePhoneCall(phone.Text);
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
                    emailTask.SendEmail(email.Text, "Hello there!", "This was sent from the Xamrain Messaging Plugin from shared code!");
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