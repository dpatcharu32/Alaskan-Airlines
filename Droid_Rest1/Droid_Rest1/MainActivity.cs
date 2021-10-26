using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;
using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using System;
using Android.Util;
using FlightScheduleApp.Models;
using FlightScheduleApp.Helpers;
using Android.Views;

namespace Droid_Rest1
{
    [Activity(Label = "Flight Details", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            TextView _dateDisplay;
            Button _dateSelectButton;
            SetContentView (Resource.Layout.Main);
            Button readXml = FindViewById<Button>(Resource.Id.readXml);
            EditText origion = FindViewById<EditText>(Resource.Id.origion);
            ListView listView = FindViewById<ListView>(Resource.Id.mainlistview);

            EditText dest = FindViewById<EditText>(Resource.Id.dest);

            _dateDisplay = FindViewById<TextView>(Resource.Id.date_display);
            DateTime dt=DateTime.Today;

            _dateSelectButton = FindViewById<Button>(Resource.Id.date_select_button);
            _dateSelectButton.Click += DateSelect_OnClick;
            void DateSelect_OnClick(object sender, EventArgs eventArgs)
            {
                DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time) {
                    _dateSelectButton.Text= time.ToLongDateString(); ;
                    _dateDisplay.Text = time.ToShortTimeString();
                    dt = Convert.ToDateTime(_dateDisplay.Text);
                });
                frag.Show(FragmentManager, DatePickerFragment.TAG);
            }
        

            readXml.Click += async delegate
            {

                RestService restService = new RestService();
                APIResponse apiresponse = await restService.GetDataAsync(origion.Text, dest.Text, dt);

                List<Flight> myList = new List<Flight>();
                
                listView.Adapter = new CusotmListAdapter(this, apiresponse.flights);


            };

            

        }

       
    }
    public class DatePickerFragment : DialogFragment,
    DatePickerDialog.IOnDateSetListener
    {
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();
        Action<DateTime> _dateSelectedHandler = delegate { };
        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            DatePickerFragment frag = new DatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            return frag;
        }
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            DatePickerDialog dialog = new DatePickerDialog(Activity, this, currently.Year, currently.Month, currently.Day);
            return dialog;
        }
        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            Log.Debug(TAG, selectedDate.ToLongDateString());
            _dateSelectedHandler(selectedDate);
        }

       

    }

    public class CusotmListAdapter : BaseAdapter<Flight>
    {
        Activity context;
        List<Flight> list;

        public CusotmListAdapter(Activity _context, List<Flight> _list)
            : base()
        {
            this.context = _context;
            this.list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Flight this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

           
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);

            Flight item = this[position];
            view.FindViewById<TextView>(Resource.Id.FlightNum).Text = item.flightDetails.operatingFlightNumber;
            view.FindViewById<TextView>(Resource.Id.Time).Text = item.flightDetails.scheduledFlightOriginationDateLocal;


            return view;
        }
    }

}

