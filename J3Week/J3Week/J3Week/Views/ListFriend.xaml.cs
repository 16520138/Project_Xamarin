using J3Week.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using J3Week.Views;

using System.IO;



namespace J3Week.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFriend : ContentPage
    {
        public ListFriend(List<Datum> listdatum)
        {
            InitializeComponent();
            
            for (int i = 0; i< listdatum.Count; i++)
            {

                Friends[i] = new Datum();
                Friends[i] = listdatum[i];
                /*
                Friends.Add(listdatum[i]);
                */
                Debug.WriteLine("Bạn " + i.ToString());
                byte[] data = Convert.FromBase64String(listdatum[i].avatar);
                Friends[i].avatar = ImageSource.FromStream(() => new MemoryStream(data)).ToString();
                
            }
        }

        private void Back(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        public List<Datum> Friends { get; set; }

        async void Lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var profile = ((ListView)sender).SelectedItem as Datum;
            if (profile == null)
                return;

            //await Navigation.PushAsync(new CustomerDetailPage(customer));
            await Navigation.PushModalAsync(new ProfileFriend(profile));
        }

        void Lst_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;
    }
}