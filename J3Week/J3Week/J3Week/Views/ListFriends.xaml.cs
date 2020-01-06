using J3Week.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J3Week.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace J3Week.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFriends : ContentPage
    {
        public ListFriends()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private void Back(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        public List<Datum> Friends { get => GetFriends(); }

        private List<Datum> GetFriends()
        {
            return new List<Datum>()
            {
                new Datum() {firstname = "Đồng Anh", lastname = "Vĩnh Cường", company = "UIT", jobtitle = "Student", email = "cuongdong7@gmail.com", phone = "0929827532", street = "Domitory A", city = "Hồ Chí Minh City",age=21 ,avatar = "https://toplist.vn/images/800px/bai-hat-hay-nhat-cua-hoa-than-vu-232556.jpg" },
                new Datum() {firstname = "Huỳnh", lastname = "Đức Huy", company = "UIT", jobtitle = "Student", email = "huynhduchuydt@gmail.com", phone = "0981403436", street = "Domitory A", city = "Hồ Chí Minh City",age=21 ,avatar = "https://znews-photo.zadn.vn/w1024/Uploaded/ohunuai/2019_02_21/NGUYEN_BA_NGOC_ZING8809.jpg" },
                new Datum() {firstname = "Thầy", lastname = "Ngọc Tân", company = "UIT", jobtitle = "Teacher", email = "tanvn@uit.edu.vn", phone = "0908290030", street = "UIT", city = "Hồ Chí Minh City",age=21 ,avatar = "https://scontent.fsgn1-1.fna.fbcdn.net/v/t31.0-8/s960x960/12968184_1014819728605897_3603816318309590140_o.jpg?_nc_cat=102&_nc_oc=AQkjWghnZgpGMY4QCsl8a9idAB8MztfQOPhpIwRroRCRW4XTwE1UcXjDmM5mufPH5Qs&_nc_ht=scontent.fsgn1-1.fna&oh=6a07a02e487dda54ae3c59beb7e401ea&oe=5E6AF886" }
            };
            
        }

        async void Lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var profile = ((ListView)sender).SelectedItem as Datum;
            if (profile == null)
                return;
            await Navigation.PushModalAsync(new ProfileFriend(profile));
        }

        void Lst_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;
    }
}