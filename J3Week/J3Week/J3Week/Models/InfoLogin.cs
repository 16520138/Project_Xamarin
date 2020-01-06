using System;
using System.Collections.Generic;
using System.Text;

namespace J3Week.Models
{
    public class UserLogin
    {
        public static string email { get; set; }
        public static string password { get; set; }
        public static string firstname { get; set; }
        public static string lastname { get; set; }
        public static string company { get; set; }
        public static string jobtitle { get; set; }
        public static string phone { get; set; }
        public static string street { get; set; }
        public static string city { get; set; }
        public static int age { get; set; }
        public static string avatar { get; set; }
        public static string name
        {
            get
            {
                return firstname + " " + lastname;
            }
        }

    }

    public class InfoLogin
    {
        public string email { get; set; }
        public string password { get; set; }

    }

    public class Datum
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string company { get; set; }
        public string jobtitle { get; set; }
        public string phone { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public int age { get; set; }
        public string avatar { get; set; }
        public int __v { get; set; }
    }

    public class ResponseLogin
    {
        public int code { get; set; }
        public Datum data { get; set; }
    }


}
