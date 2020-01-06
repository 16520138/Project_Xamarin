using J3Week.Models;
using J3Week.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace J3Week.ViewModels
{
    public class LoginViewModel
    {

        private InfoLogin infologin = new InfoLogin();

        public InfoLogin InfoLogin
        {
            get { return infologin; }
            set
            {
                infologin = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation { get; set; }
        public Command LoginCommand { get; }
        
        public LoginViewModel(INavigation appNav)
        {
            Navigation = appNav;
            LoginCommand = new Command(async () => await ExeLoginCommand());

        }

        private async Task ExeLoginCommand()
        {
            Debug.WriteLine("Call Login funtion -------------------------------------");
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://safe-ravine-18352.herokuapp.com");

            Debug.WriteLine("Tạo object data");

            Debug.WriteLine(InfoLogin.email);
            Debug.WriteLine(InfoLogin.password);



            var data = new InfoLogin()
            {
                //email = "dothithuyhangc12@gmail",
                //password = "123"
                // Tắt đi thì không cần login

                email = InfoLogin.email,
                password = InfoLogin.password,

            };
            Debug.WriteLine("Chuyển json data");
            string jsonMessage = JsonConvert.SerializeObject(data);
            //string jsonData = @"{""Email"" : ""eri@email"", ""Passwords"" : ""123""}";

            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("/foo/login", content);

            HttpResponseMessage response = await client.PostAsync("/users/login", content);

            string result = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("Kết quả");
            Debug.WriteLine(result);


            Debug.WriteLine("Chuyển object");
            ResponseLogin responselogin = JsonConvert.DeserializeObject<ResponseLogin>(result);
            Debug.WriteLine(responselogin.ToString());

            Debug.WriteLine("Gọi if");
            if (responselogin.code == 1)
            {
                Debug.WriteLine("Đúng");

                Debug.WriteLine("Thông tin");

                UserLogin.email = responselogin.data.email;
                UserLogin.firstname = responselogin.data.firstname;
                UserLogin.lastname = responselogin.data.lastname;
                UserLogin.company = responselogin.data.company;
                UserLogin.jobtitle = responselogin.data.jobtitle;
                UserLogin.phone = responselogin.data.phone;
                UserLogin.street = responselogin.data.street;
                UserLogin.city = responselogin.data.city;
                UserLogin.age = responselogin.data.age;
                UserLogin.avatar = responselogin.data.avatar;

                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Notification", "Error Login", "Okay");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
