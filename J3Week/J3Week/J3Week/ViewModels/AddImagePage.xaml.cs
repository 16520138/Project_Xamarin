using J3Week.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templates;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
using System.Net.Http;


namespace J3Week.ViewModels
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddImagePage : ContentPage
    {
        public AddImagePage(string ID)
        {
            InitializeComponent();
            NewImg.Source = NewImageHelper.Images[ID];
            Setup();
        }

        private async void ReturnHome(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void Setup()
        {
            foreach (FormsUser Item in TemplateData.Users)
            {
                UserPicker.Items.Add(Item.Name);
            }
            foreach (Location Item in TemplateData.Locations)
            {
                LocationPicker.Items.Add(Item.Name);
            }
            UserPicker.SelectedIndex = 0;
            LocationPicker.SelectedIndex = 0;
        }

        FormsUser GetUser(string Name)
        {
            foreach (FormsUser Item in TemplateData.Users)
            {
                if (Item.Name.Equals(Name))
                {
                    return Item;
                }
            }
            return null;
        }

        Location GetLocation(string Name)
        {
            foreach (Location Item in TemplateData.Locations)
            {
                if (Item.Name.Equals(Name))
                {
                    return Item;
                }
            }
            return null;
        }

        async void Save(object sender, EventArgs e)
        {
            
            PostListModel.getLenPost();
            
            Post NewPost = new Post()
            {
                Picture = NewImg.Source,
                PostDate = DateTime.Now,
                PostLocation = GetLocation((string)LocationPicker.SelectedItem),
                User = GetUser((string)UserPicker.SelectedItem),
                Title = PostTitle.Text
            };

            PostListModel.AddPost(NewPost);
            PostListModel.Filter();
            await Navigation.PopModalAsync();

            
            PostListModel.getLenPost();
        }
    }
}