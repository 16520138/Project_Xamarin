using J3Week.Models;
using J3Week.ViewModels;
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
    public partial class SettingsMultiSelectComponent : StackLayout
    {
        MultiSelectePage MutliSelect;

        public SettingsMultiSelectComponent()
        {
            InitializeComponent();
            MutliSelect = new MultiSelectePage(this);
        }

        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set
            {
                SetValue(TitleProperty, value);
                MutliSelect.SetTitle(value);
                TitleLbl.Text = value;
                SetSelectedLbl("All " + Title);
            }
        }
        public static readonly BindableProperty TitleProperty = BindableProperty.Create
            (
            propertyName: "Title",
            returnType: typeof(string),
            declaringType: typeof(SettingsSingleSelectComponent),
            defaultValue: "",
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitleChanged
            );

        public static void TitleChanged(BindableObject Bindable, object OldValue, object NewValue)
        {
            SettingsMultiSelectComponent Control = (SettingsMultiSelectComponent)Bindable;
            Control.Title = (string)NewValue;
        }

        public void InitialiseMutliSelect(Dictionary<IMultiSelectModel, bool> Items)
        {
            MutliSelect.InitialiseMutliSelect(Items);
        }

        void OpenMultiSelect(object sender, System.EventArgs e)
        {
            if (MutliSelect.IsOpen == false)
            {
                Navigation.PushModalAsync(MutliSelect);
            }
        }

        public void SetSelectedLbl(string NewLbl)
        {
            SelectedLbl.Text = NewLbl;
        }
    }
}