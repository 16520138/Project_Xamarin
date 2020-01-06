using J3Week.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace J3Week.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsComponent : StackLayout
    {
		public SettingsComponent ()
		{
			InitializeComponent ();
		}
        public void InitialiseSettingsElements()
        {
            InitialiseDatePicker();
            InitialiseLocationSelector();
            InitialiseUsersSelector();
        }

        void InitialiseDatePicker()
        {
            Dictionary<string, object> DateItems = new Dictionary<string, object>()
            {
                {"All time", null },
                {"Today", DateTime.Now },
                {"Yesterday", DateTime.Now.AddDays(-1) },
                {"2 day ago", DateTime.Now.AddDays(-2) },
                {"3 days ago", DateTime.Now.AddDays(-3) },
                {"4 days ago", DateTime.Now.AddDays(-4) }
            };

            DateElement.InitialisePicker(DateItems);
        }

        void InitialiseLocationSelector()
        {
            LocationElement.InitialiseMutliSelect(FilterPreferences.Locations);
        }

        void InitialiseUsersSelector()
        {
            UserElement.InitialiseMutliSelect(FilterPreferences.ActiveUsers);
        }

        private void ApplyFilter(object sender, EventArgs e)
        {
            UpdateDatePreference();
            PostListModel.Filter();
        }

        void UpdateDatePreference()
        {
            if (DateElement.GetSelectedItem() != null)
            {
                FilterPreferences.Date = (DateTime)DateElement.GetSelectedItem();
            }
            else
            {
                FilterPreferences.Date = null;
            }
        }
    }
}