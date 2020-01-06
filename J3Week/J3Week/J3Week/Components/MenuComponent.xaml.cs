using J3Week.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using J3Week.Models;
using System.Diagnostics;
using System.IO;

using System.Net.Http;
using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

namespace J3Week.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuComponent : StackLayout
    {
        public ImageSource avatar { get => GetAvatar(); }

        private ImageSource GetAvatar()
        {

            byte[] data = Convert.FromBase64String(UserLogin.avatar);
            return ImageSource.FromStream(() => new MemoryStream(data));
        }

        public Datum user { get => GetUserInfo(); }
        private Datum GetUserInfo()
        {
            Debug.WriteLine("Error convert");
            Debug.WriteLine("MenuComponent");
           
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

        public MenuComponent ()
		{
			InitializeComponent ();
            BindingContext = this;

        }
        private void Profile(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new Views.Profile());
        }
        /*
        private async void Friend(object sender, EventArgs e)
        {

            //start 
            Debug.WriteLine("Call get Friends funtion -------------------------------------");
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://safe-ravine-18352.herokuapp.com");

            HttpResponseMessage response = await client.GetAsync("/users");

            string result = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("Kết quả");
            Debug.WriteLine(result);

            Debug.WriteLine("Chuyển object");
            var contentJo = (JObject)JsonConvert.DeserializeObject(result);
            var organizationsJArray = contentJo["data"]
                .Value<JArray>();

            var listfriend = organizationsJArray.ToObject<List<Datum>>();


            Debug.WriteLine("Số lượng friends");
            Debug.WriteLine(listfriend.Count);
            Debug.WriteLine(listfriend.ToString());

            //end

            //Navigation.PushModalAsync(new ListFriends());
            Navigation.PushModalAsync(new ListFriend(listfriend));
        }
        */

        private void Friends(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ListFriends());
        }
    }
}