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
    class MyListViewAdapter : BaseAdapter<Weather>
    {
        private List<Weather> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context,List<Weather> items)
        {
            mItems = items;
            mContext = context;
        }

        public override int Count
        {
            get {return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Weather this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            
            if(row == null) 
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView txtDate = row.FindViewById<TextView>(Resource.Id.txtDate);
            txtDate.Text = "1"+position+".05";

            TextView txtWeather = row.FindViewById<TextView>(Resource.Id.txtWeather);
            txtWeather.Text = mItems[position].mWeather;

            TextView txtTempreture = row.FindViewById<TextView>(Resource.Id.txtTempreture);
            txtTempreture.Text = mItems[position].mTempreture.ToString();

            ImageView imageWeather = row.FindViewById<ImageView>(Resource.Id.imageWeather);
            if(mItems[position].mWeather=="Sunny")
            {
                imageWeather.SetImageResource(Resource.Drawable.sunny);
            }
            else if (mItems[position].mWeather == "Rainy")
            {
                imageWeather.SetImageResource(Resource.Drawable.rain);
            }
            else
            {
                imageWeather.SetImageResource(Resource.Drawable.clouds);
            }

                return row;
        }
    }
}