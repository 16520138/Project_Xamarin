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
	public partial class EmptyListViewMessage : StackLayout
    {
        public EmptyListViewMessage()
        {
            InitializeComponent();
            ChangeState(false); // Disable on start
        }

        public void ChangeState(bool State)
        {
            IsEnabled = State;
            IsVisible = State;
        }
    }
}