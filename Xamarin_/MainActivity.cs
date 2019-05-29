using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using SQLite;

namespace Xamarin_
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private List<Weather> mItems;
        private ListView mListView;
        MyListViewAdapter adapter;

        public List<int> alreadyGuessed = new List<int>();

        public void Save(SQLiteConnection db)
        {
            db.CreateTable<Weather>();
            db.DeleteAll<Weather>();
            for (int i = 0; i <= 9; i++)
            {
                db.Insert(mItems[i]);
                Console.WriteLine("{0}", mItems[i].mTempreture);
            }
        }

        public void Load(SQLiteConnection db)
        {
            /*
            for (int i = 0; i <= 9; i++)
            {
                mItems[i] = db.Get<Weather>(i);
                Console.WriteLine("{0}",mItems[i].mTempreture);
            }
            */
            int i = 0;
            foreach(Weather obj in db.Table<Weather>())
            {
                if (i <= 9)
                {
                    mItems[i] = obj;
                    Console.WriteLine("{0}", mItems[i].mTempreture);
                    i++;
                }
            }
            adapter = new MyListViewAdapter(this, mItems);
            mListView.Adapter = adapter;

        }

        public void Check(SQLiteConnection db)
        {
            int i = 0;
            foreach (Weather obj in db.Table<Weather>())
            {
                System.Diagnostics.Debug.Write(obj.mTempreture);
                i++;
            }

        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            mListView = FindViewById<ListView>(Resource.Id.myListView);


            var dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CanFindLocation");
            var db = new SQLiteConnection(dbPath);

            Random generator = new Random();
            
            mItems = new List<Weather>();
            mItems.Add(new Weather() { mWeather = "Cloudy", mTempreture = 17 });
            mItems.Add(new Weather() { mWeather = "Cloudy", mTempreture = 17 });
            mItems.Add(new Weather() { mWeather = "Sunny", mTempreture = 26 });
            mItems.Add(new Weather() { mWeather = "Rainy", mTempreture = 4 });
            mItems.Add(new Weather() { mWeather = "Cloudy", mTempreture = 13 });
            mItems.Add(new Weather() { mWeather = "Sunny", mTempreture = 26 });
            mItems.Add(new Weather() { mWeather = "Rainy", mTempreture = -1 });
            mItems.Add(new Weather() { mWeather = "Cloudy", mTempreture = 17 });
            mItems.Add(new Weather() { mWeather = "Sunny", mTempreture = 26 });
            mItems.Add(new Weather() { mWeather = "Rainy", mTempreture = 0 });
            

            //int num;
            /*
            for(int i=0;i<=9;i++)
            {
                var random = new Random(13*i);
                num = random.Next(0, 30);
                while (alreadyGuessed.Contains(num))
                {
                    num = random.Next(0, 30);
                }
                alreadyGuessed.Add(num);
                mItems.Add(new Weather(num));
            }
            */
            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            mListView.Adapter = adapter;

            mListView.ItemClick += MListView_ItemClick;

            void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                Console.WriteLine(mItems[e.Position].mWeather);
            }

            mListView.ItemLongClick += MListView_ItemLongClick;
            mListView.ItemLongClick += MListView_ItemLongClick1;


            void MListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
            {
                Console.WriteLine(mItems[e.Position].mTempreture);
            }

            void MListView_ItemLongClick1(object sender, AdapterView.ItemLongClickEventArgs e)
            {
                Console.WriteLine(mItems[e.Position].mWeather);
            }

            
            var btnSave = FindViewById<Button>(Resource.Id.btnsave);
            var btnLoad = FindViewById<Button>(Resource.Id.btnload);
            var btnCheck = FindViewById<Button>(Resource.Id.btncheck);
            btnSave.Click += (e, o) =>
            {
                Save(db);
            };

            btnLoad.Click += (e, o) =>
            {
                Load(db);
            };
            btnCheck.Click += (e, o) =>
            {
                Check(db);
            };


            /*
            var btnSunny = FindViewById<Button>(Resource.Id.btnSunny);
            var btnCloud = FindViewById<Button>(Resource.Id.btnCloud);
            var btnRain = FindViewById<Button>(Resource.Id.btnRain);
            */
            /*
            btnSunny.Click += (e, o) => {
                imageView.SetImageResource(Resource.Drawable.sunny);

                btnSunny.Visibility = Android.Views.ViewStates.Invisible;
                btnCloud.Visibility = Android.Views.ViewStates.Visible;
                btnRain.Visibility = Android.Views.ViewStates.Visible;
            };

            btnCloud.Click += (e, o) => {
                imageView.SetImageResource(Resource.Drawable.clouds);

                btnSunny.Visibility = Android.Views.ViewStates.Visible;
                btnCloud.Visibility = Android.Views.ViewStates.Invisible;
                btnRain.Visibility = Android.Views.ViewStates.Visible;
            };

            btnRain.Click += (e, o) => {
                imageView.SetImageResource(Resource.Drawable.rain);

                btnSunny.Visibility = Android.Views.ViewStates.Visible;
                btnCloud.Visibility = Android.Views.ViewStates.Visible;
                btnRain.Visibility = Android.Views.ViewStates.Invisible;
            };
            */
            /*
            FindViewById<Button>(Resource.Id.btnInc).Click += (o, e) =>
            txtNumber.Text = (++number).ToString();

            FindViewById<Button>(Resource.Id.btnDec).Click += (o, e) =>
            txtNumber.Text = (--number).ToString();

            FindViewById<Button>(Resource.Id.btnMult).Click += (o, e) =>
            txtNumber.Text = (number*=2).ToString();
            */
            /*
              <TextView
        android:text="0"
        android:textSize="50sp"
        android:gravity="center"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/txtNumber"
        android:layout_marginBottom="20dp"
        android:layout_marginTop="20dp" />

    <Button
        android:text="Sunny"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:layout_below="@id/imageView"
        android:id="@+id/btnSunny" />
    <Button
        android:text="Cloud"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:layout_below="@id/btnSunny"
        android:id="@+id/btnCloud" />
    <Button
        android:text="Rain"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:layout_below="@id/btnCloud"
        android:id="@+id/btnRain" />
        */


        }

    }
}
 