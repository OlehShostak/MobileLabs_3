using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Xamarin_
{
    class Weather
    {
        public Weather()
        {
            mTempreture = 69;
            mWeather = "Rainy";
        }
        public Weather(int num)
        {
            mTempreture = num;
            if (mTempreture<=10)
            {
                mWeather = "Rainy";
            }
            else if(mTempreture<=20)
            {
                mWeather = "Cloudy";
            }
            else
            {
                mWeather = "Sunny";
            }
            
        }

        public string mWeather { get; set; }
        public int mTempreture { get; set; }
    }
}