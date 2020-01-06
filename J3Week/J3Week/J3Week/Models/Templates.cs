using J3Week.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Templates
{
    public static class TemplateData
    {
        public static bool HasTemplateDataBeenInitialised()
        {
            return Application.Current.Properties.ContainsKey("initialised");
        }

        public static List<Post> GetTemplatePosts(List<FormsUser> Users, List<Location> Locations) // Creates 6 posts with the 4 users
        {
            List<Post> Posts = new List<Post>
            {
                new Post
                {
                    User = Users[0],
                    PostDate = DateTime.Now.AddDays(-5),
                    PostLocation = Locations[0],
                    Title = "Happy new year",
                    Picture = ImageSource.FromFile("post1.jpg")
                },

                new Post
                {
                    User = Users[1],
                    PostDate = DateTime.Now.AddDays(-4),
                    PostLocation = Locations[1],
                    Title = "Let's way back home",
                    Picture = ImageSource.FromFile("post2.png")
                },

                new Post
                {
                    User = Users[2],
                    PostDate = DateTime.Now.AddDays(-3),
                    PostLocation = Locations[2],
                    Title = "Spring is comming!",
                    Picture = ImageSource.FromFile("post3.jpg")
                },

                new Post
                {
                    User = Users[2],
                    PostDate = DateTime.Now.AddDays(-2),
                    PostLocation = Locations[3],
                    Title = " I love you for being my true friend",
                    Picture = ImageSource.FromFile("post4.png")
                },

                new Post
                {
                    User = Users[0],
                    PostDate = DateTime.Now.AddDays(-1),
                    PostLocation = Locations[0],
                    Title = "I love my family",
                    Picture = ImageSource.FromFile("post5.jpg")
                },

                new Post
                {
                    User = Users[1],
                    PostDate = DateTime.Now,
                    PostLocation = Locations[1],
                    Title = "Happy New Year to you, Mom and Dad",
                    Picture = ImageSource.FromFile("post6.jpg")
                }
            };

            return Posts;
        }

        public static List<Location> Locations = new List<Location>()
        {
            new Location
            {
                Name = "Los Angeles",
            },

                new Location
                {
                    Name = "New York",
                },

                new Location
                {
                    Name = "Paris",
                },

                new Location
                {
                    Name = "London",
                },
        };

        public static List<FormsUser> Users = new List<FormsUser>() // Creates 4 users
        {
                new FormsUser
                {
                    FirstName = "Đỗ Thị",
                    LastName = "Thúy Hằng",
                    //ProfilePicture = ImageSource.FromFile("user1.png")
                    Avatar = "https://scontent.fsgn5-6.fna.fbcdn.net/v/t1.0-1/61400827_1189192927931563_3402428823663280128_n.jpg?_nc_cat=106&_nc_oc=AQmMgWZOETD0K69AhDLI5qFu-QHhpJIrsch9KzZp_XTIlVgT1rWpyKNpkUf-tz0aWwg&_nc_ht=scontent.fsgn5-6.fna&oh=af79cfe2979ac4a408812b569b08ccd8&oe=5EB0CA61"
                },

                new FormsUser
                {
                    FirstName = "Huỳnh",
                    LastName = "Đức Huy",
                    //ProfilePicture = ImageSource.FromFile("user2.png")
                    Avatar = "https://znews-photo.zadn.vn/w1024/Uploaded/ohunuai/2019_02_21/NGUYEN_BA_NGOC_ZING8809.jpg"
                },

                new FormsUser
                {
                    FirstName = "Đồng Anh",
                    LastName = "Vĩnh Cường",
                   //ProfilePicture = ImageSource.FromFile("user3.png")
                    Avatar = "https://toplist.vn/images/800px/bai-hat-hay-nhat-cua-hoa-than-vu-232556.jpg"
                },

              
        };
    }
}
