using J3Week.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace J3Week.Models
{
    public class Post : INotifyPropertyChanged
    {
        public FormsUser User { get; set; }
        public DateTime PostDate { get; set; }
        public Location PostLocation { get; set; }
        public PostState State { get; set; } = PostState.Unliked;
        public string Title { get; set; }
        public ImageSource Picture { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ObservableStateChange(PostState NewState) // Use this to invoke the collection/property changed event
        {
            State = NewState;
            NotifyPropertyChanged("State");
        }
    }
}